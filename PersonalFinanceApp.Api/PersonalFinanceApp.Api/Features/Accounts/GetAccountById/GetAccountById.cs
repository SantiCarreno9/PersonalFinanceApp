using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceApp.Api.Core.Abstractions.Authentication;
using PersonalFinanceApp.Api.Core.Abstractions.Messaging;
using PersonalFinanceApp.Api.Core.Endpoints;
using PersonalFinanceApp.Api.Database;
using PersonalFinanceApp.Api.Entities;
using PersonalFinanceApp.Api.Errors;
using PersonalFinanceApp.Api.Features.Accounts.Common;

namespace PersonalFinanceApp.Api.Features.Accounts.GetAccountById;

public static class GetAccountById
{
    public record Query(int Id) : IQuery<Response>;
    public record Response
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string AccountType { get; init; }
        public decimal Balance { get; init; }
    }
    internal sealed class Handler(
        IApplicationDbContext context,
        IUserContext userContext)
        : IQueryHandler<Query, Response>
    {
        public async Task<Result<Response>> Handle(Query query, CancellationToken cancellationToken)
        {
            Account existingAccount = await context.Accounts.Include(a => a.Users).AsNoTracking().Where(a => a.Id == query.Id).SingleOrDefaultAsync(cancellationToken);
            if (existingAccount == null)
            {
                return Result.Failure<Response>(AccountErrors.NotFound(query.Id));
            }

            if (existingAccount.Users.FirstOrDefault(u => u.Id.Equals(userContext.UserId, StringComparison.Ordinal)) == null)
            {
                return Result.Failure<Response>(UserErrors.Unauthorized());
            }

            return new Response
            {
                Id = existingAccount.Id,
                AccountType = existingAccount.AccountType.ToString(),
                Name = existingAccount.Name,
                Balance = existingAccount.Balance
            };
        }
    }

    public sealed class Endpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet(EndpointsBase.AccountsBasePath + "/{accountId}", async (
                int accountId,
                [FromServices] IQueryHandler<Query, Response> handler,
                CancellationToken cancellationToken
                ) =>
            {
                var query = new Query(accountId);

                Result<Response> result = await handler.Handle(query, cancellationToken);

                return result.Match(Results.Ok, CustomResults.Problem);

            })
            .Produces<Response>(StatusCodes.Status200OK)
            .RequireAuthorization()
            .WithTags(Tags.Accounts);

        }
    }
}
