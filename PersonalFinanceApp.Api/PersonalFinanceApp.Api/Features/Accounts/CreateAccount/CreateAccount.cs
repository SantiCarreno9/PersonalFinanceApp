using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceApp.Api.Core.Abstractions.Authentication;
using PersonalFinanceApp.Api.Core.Abstractions.Messaging;
using PersonalFinanceApp.Api.Core.Endpoints;
using PersonalFinanceApp.Api.Database;
using PersonalFinanceApp.Api.Entities;
using PersonalFinanceApp.Api.Errors;
using PersonalFinanceApp.Api.Features.Accounts.Common;

namespace PersonalFinanceApp.Api.Features.Accounts.CreateAccount;

public static class CreateAccount
{
    public record Command(string Name, string AccountType) : ICommand<AccountResponse>;

    internal sealed class AccountValidator : AbstractValidator<Command>
    {
        public AccountValidator()
        {
            RuleFor(c => c.Name).NotEmpty().MinimumLength(5);
            RuleFor(c => c.AccountType).NotEmpty().IsEnumName(typeof(AccountType), caseSensitive: false);
        }
    }
    internal sealed class Handler(
        IApplicationDbContext context,
        IUserContext userContext)
        : ICommandHandler<Command, AccountResponse>
    {
        public async Task<Result<AccountResponse>> Handle(Command command, CancellationToken cancellationToken)
        {
            User user = await context.Users.Where(u => u.Id == userContext.UserId).SingleOrDefaultAsync(cancellationToken);
            if (user == null)
            {
                return Result.Failure<AccountResponse>(UserErrors.NotFound(userContext.UserId));
            }
            var account = new Account
            {
                Name = command.Name,
                AccountType = Enum.Parse<AccountType>(command.AccountType, true),
                Users = [user]
            };

            await context.Accounts.AddAsync(account, cancellationToken);

            await context.SaveChangesAsync(cancellationToken);

            return new AccountResponse
            {
                Id = account.Id,
                Name = account.Name,
                AccountType = account.AccountType.ToString(),
                Balance = account.Balance
            };
        }
    }

    public sealed class Endpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost(EndpointsBase.AccountsBasePath, async (
                [FromBody] Command command,
                [FromServices] ICommandHandler<Command, AccountResponse> handler,
                CancellationToken cancellationToken
                ) =>
            {

                Result<AccountResponse> result = await handler.Handle(command, cancellationToken);

                if (result.IsFailure)
                {
                    return CustomResults.Problem(result);
                }
                return Results.Created(EndpointsBase.AccountsBasePath, result.Value);

            })
            .Produces<AccountResponse>(StatusCodes.Status201Created)
            .RequireAuthorization()
            .WithTags(Tags.Accounts);

        }
    }
}
