

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceApp.Api.Core.Abstractions.Messaging;
using PersonalFinanceApp.Api.Core.Endpoints;
using PersonalFinanceApp.Api.Database;
using PersonalFinanceApp.Api.Entities;
using PersonalFinanceApp.Api.Errors;
using PersonalFinanceApp.Api.Features.Users.Common;

namespace PersonalFinanceApp.Api.Features.Users.Login;

public static class Login
{    
    public record Command(string Email, string Password) : ICommand<LoginResponse>;

    internal sealed class Handler(
        IApplicationDbContext context,
        IPasswordHasher passwordHasher,
        ITokenProvider tokenProvider)
        : ICommandHandler<Command, LoginResponse>
    {
        public async Task<Result<LoginResponse>> Handle(Command command, CancellationToken cancellationToken)
        {
            User? user = await context.Users
            .AsNoTracking()
            .SingleOrDefaultAsync(u => u.Email == command.Email, cancellationToken);

            if (user is null)
            {
                return Result.Failure<LoginResponse>(UserErrors.NotFoundByEmail);
            }

            bool verified = passwordHasher.Verify(command.Password, user.PasswordHash);

            if (!verified)
            {
                return Result.Failure<LoginResponse>(UserErrors.NotFoundByEmail);
            }

            string token = tokenProvider.Create(user);

            var refreshToken = new RefreshToken
            {
                Id = Guid.NewGuid().ToString(),
                UserId = user.Id,
                Token = tokenProvider.GenerateRefreshToken(),
                ExpiresOnUtc = DateTime.UtcNow.AddDays(7)
            };

            context.RefreshTokens.Add(refreshToken);

            await context.SaveChangesAsync(cancellationToken);

            return new LoginResponse(token, refreshToken.Token);
        }
    }

    public sealed class Endpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost(EndpointsBase.UsersBasePath + "/login", async (
                bool? useCookies,
                [FromBody] Command request,
                [FromServices] ICommandHandler<Command,LoginResponse> handler,
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
