using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceApp.Api.Core.Abstractions.Authentication;
using PersonalFinanceApp.Api.Core.Abstractions.Messaging;
using PersonalFinanceApp.Api.Core.Endpoints;
using PersonalFinanceApp.Api.Database;
using PersonalFinanceApp.Api.Entities;
using PersonalFinanceApp.Api.Errors;
using PersonalFinanceApp.Api.Features.Accounts.Common;
using PersonalFinanceApp.Api.Features.Users.Common;

namespace PersonalFinanceApp.Api.Features.Accounts.GetMyAccounts;

public static class GetMyAccounts
{
    public record Query() : IQuery<IList<AccountResponse>>;
    internal sealed class Handler(
        IApplicationDbContext context,
        IUserContext userContext)
        : IQueryHandler<Query, IList<AccountResponse>>
    {
        public async Task<Result<IList<AccountResponse>>> Handle(Query query, CancellationToken cancellationToken)
        {
            List<AccountResponse> myAccounts = await context.Users
                .Where(u => u.Id == userContext.UserId)
                .SelectMany(u => u.Accounts)
                .Select(a => new AccountResponse
                {
                    Id = a.Id,
                    Name = a.Name,
                    AccountType = a.AccountType.ToString(),
                    Balance = a.Balance
                })
                .ToListAsync(cancellationToken);

            return myAccounts;
        }
    }

    public sealed class Endpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet(EndpointsBase.AccountsBasePath, async (
                [FromServices] IQueryHandler<Query, IList<AccountResponse>> handler,
                CancellationToken cancellationToken
                ) =>
            {
                var query = new Query();

                Result<IList<AccountResponse>> result = await handler.Handle(query, cancellationToken);

                return result.Match(Results.Ok, CustomResults.Problem);

            })
            .Produces<IList<AccountResponse>>(StatusCodes.Status200OK)
            .RequireAuthorization()
            .WithTags(Tags.Accounts);

        }
    }
}
