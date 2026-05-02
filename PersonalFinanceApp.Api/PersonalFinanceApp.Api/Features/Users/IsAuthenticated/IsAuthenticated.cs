

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceApp.Api.Core.Abstractions.Authentication;
using PersonalFinanceApp.Api.Core.Abstractions.Messaging;
using PersonalFinanceApp.Api.Core.Endpoints;
using PersonalFinanceApp.Api.Database;
using PersonalFinanceApp.Api.Errors;

namespace PersonalFinanceApp.Api.Features.Users.IsAuthenticated;

public static class IsAuthenticated
{
    public record Response
    {
        public string Id { get; init; }
        public string Email { get; init; }
        public string FullName { get; init; }
    }
    public record Query() : IQuery<Response>;

    internal sealed class Handler(
        IApplicationDbContext context,
        IUserContext userContext)
        : IQueryHandler<Query, Response>
    {
        public async Task<Result<Response>> Handle(Query query, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(userContext.UserId))
            {
                return Result.Failure<Response>(UserErrors.Unauthorized());
            }

            Response? response = await context.Users
                .Where(u => u.Id == userContext.UserId)
                .Select(u => new Response
                {
                    Id = u.Id,
                    FullName = u.FullName,
                    Email = u.Email
                })
                .SingleAsync(cancellationToken);

            if (response is null)
            {
                return Result.Failure<Response>(UserErrors.NotFound(userContext.UserId));
            }

            return response;
        }
    }

    public sealed class Endpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost(EndpointsBase.UsersBasePath + "/me", async (
                [FromServices] IQueryHandler<Query, Response> handler,
                CancellationToken cancellationToken
                ) =>
            {
                var query = new Query();
                Result<Response> result = await handler.Handle(query, cancellationToken);

                return result.Match(Results.Ok, CustomResults.Problem);

            })
            .Produces<Response>(StatusCodes.Status200OK)
            .RequireAuthorization()
            .WithTags(Tags.Users);

        }
    }
}
