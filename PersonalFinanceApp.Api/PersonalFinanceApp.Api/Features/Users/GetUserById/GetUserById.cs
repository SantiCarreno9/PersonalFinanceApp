using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceApp.Api.Core.Abstractions.Authentication;
using PersonalFinanceApp.Api.Core.Abstractions.Messaging;
using PersonalFinanceApp.Api.Core.Endpoints;
using PersonalFinanceApp.Api.Database;
using PersonalFinanceApp.Api.Errors;
using PersonalFinanceApp.Api.Features.Users.Common;

namespace PersonalFinanceApp.Api.Features.Users.GetUserById;

public static class GetUserById
{
    public record Query(string UserId) : IQuery<UserResponse>;

    internal sealed class Handler(
        IApplicationDbContext context,
        IUserContext userContext)
        : IQueryHandler<Query, UserResponse>
    {
        public async Task<Result<UserResponse>> Handle(Query query, CancellationToken cancellationToken)
        {
            if (query.UserId != userContext.UserId)
            {
                return Result.Failure<UserResponse>(UserErrors.Unauthorized());
            }

            UserResponse? user = await context.Users
                .Where(u => u.Id == query.UserId)
                .Select(u => new UserResponse
                {
                    Id = u.Id,
                    FullName = u.FullName,
                    Email = u.Email
                })
                .SingleOrDefaultAsync(cancellationToken);

            if (user is null)
            {
                return Result.Failure<UserResponse>(UserErrors.NotFound(query.UserId));
            }

            return user;
        }
    }

    public sealed class Endpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost(EndpointsBase.UsersBasePath + "/{userId}", async (
                string userId,
                [FromServices] IQueryHandler<Query, UserResponse> handler,
                CancellationToken cancellationToken
                ) =>
            {
                var query = new Query(userId);

                Result<UserResponse> result = await handler.Handle(query, cancellationToken);

                return result.Match(Results.Ok, CustomResults.Problem);

            })
            .Produces<LoginResponse>(StatusCodes.Status200OK)
            .WithTags(Tags.Users);

        }
    }
}
