

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceApp.Api.Core.Abstractions.Messaging;
using PersonalFinanceApp.Api.Core.Endpoints;
using PersonalFinanceApp.Api.Database;
using PersonalFinanceApp.Api.Entities;
using PersonalFinanceApp.Api.Errors;
using PersonalFinanceApp.Api.Features.Users.Common;

namespace PersonalFinanceApp.Api.Features.Users.LoginWithRefreshToken;

public static class LoginWithRefreshToken
{    
    public record Command(string RefreshToken) : ICommand<LoginResponse>;

    internal sealed class Handler(
        IApplicationDbContext context,        
        ITokenProvider tokenProvider)
        : ICommandHandler<Command, LoginResponse>
    {
        public async Task<Result<LoginResponse>> Handle(Command command, CancellationToken cancellationToken)
        {
            RefreshToken? refreshToken = await context.RefreshTokens
            .Include(r => r.User)
            .FirstOrDefaultAsync(r => r.Token == command.RefreshToken, cancellationToken);

            if (refreshToken == null || refreshToken.ExpiresOnUtc < DateTime.UtcNow)
            {
                return Result.Failure<LoginResponse>(UserErrors.RefreshTokenExpired);
            }

            string accessToken = tokenProvider.Create(refreshToken.User);

            refreshToken.Token = tokenProvider.GenerateRefreshToken();
            refreshToken.ExpiresOnUtc = DateTime.UtcNow.AddDays(7);

            await context.SaveChangesAsync(cancellationToken);

            return new LoginResponse(accessToken, refreshToken.Token);
        }
    }

    public sealed class Endpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost(EndpointsBase.UsersBasePath + "/refresh-token", async (
                bool? useCookies,
                [FromBody] Command request,
                [FromServices] ICommandHandler<Command, LoginResponse> handler,
                IHttpContextAccessor httpContextAccessor,
                IConfiguration configuration,
                CancellationToken cancellationToken
                ) =>
            {
                Result<LoginResponse> result = await handler.Handle(request, cancellationToken);

                if (result.IsSuccess && useCookies.HasValue && useCookies.Value && httpContextAccessor.HttpContext is not null)
                {
                    CookiesManagementExtension.SetTokensInsideCookies(result.Value, httpContextAccessor.HttpContext, configuration);
                    return Results.Ok();
                }

                return result.Match(Results.Ok, CustomResults.Problem);

            })
            .Produces<LoginResponse>(StatusCodes.Status200OK)
            .WithTags(Tags.Users);

        }
    }
}
