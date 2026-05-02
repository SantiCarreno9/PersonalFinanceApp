using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceApp.Api.Core.Abstractions.Authentication;
using PersonalFinanceApp.Api.Core.Abstractions.Messaging;
using PersonalFinanceApp.Api.Core.Endpoints;
using PersonalFinanceApp.Api.Database;
using PersonalFinanceApp.Api.Entities;
using PersonalFinanceApp.Api.Errors;

namespace PersonalFinanceApp.Api.Features.Accounts.DeleteAccountById;

public static class DeleteAccountById
{
    public record Command(int Id) : ICommand;
    
    internal sealed class Handler(
        IApplicationDbContext context,
        IUserContext userContext)
        : ICommandHandler<Command>
    {
        public async Task<Result> Handle(Command query, CancellationToken cancellationToken)
        {
            Account existingAccount = await context.Accounts.Include(a => a.Users).Where(a => a.Id == query.Id).SingleOrDefaultAsync(cancellationToken);
            if (existingAccount == null)
            {
                return Result.Failure(AccountErrors.NotFound(query.Id));
            }

            User? foundUser = existingAccount.Users.FirstOrDefault(u => u.Id.Equals(userContext.UserId, StringComparison.Ordinal));
            if (foundUser == null)
            {
                return Result.Failure(UserErrors.Unauthorized());
            }

            if (existingAccount.Users.Count == 1)
            {
                await context.Accounts.Where(a => a.Id == query.Id).ExecuteDeleteAsync(cancellationToken);
            }
            else
            {
                existingAccount.Users.Remove(foundUser);
                await context.SaveChangesAsync(cancellationToken);
            }            

            return Result.Success();
        }
    }

    public sealed class Endpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapDelete(EndpointsBase.AccountsBasePath + "/{accountId}", async (
                int accountId,
                [FromServices] ICommandHandler<Command> handler,
                CancellationToken cancellationToken
                ) =>
            {
                var command = new Command(accountId);

                Result result = await handler.Handle(command, cancellationToken);

                return result.Match(Results.NoContent, CustomResults.Problem);

            })
            .Produces(StatusCodes.Status204NoContent)
            .RequireAuthorization()
            .WithTags(Tags.Accounts);

        }
    }
}
