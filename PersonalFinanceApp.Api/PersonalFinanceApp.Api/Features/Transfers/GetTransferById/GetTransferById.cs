using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceApp.Api.Core.Abstractions.Authentication;
using PersonalFinanceApp.Api.Core.Abstractions.Messaging;
using PersonalFinanceApp.Api.Core.Endpoints;
using PersonalFinanceApp.Api.Database;
using PersonalFinanceApp.Api.Entities;
using PersonalFinanceApp.Api.Errors;
using PersonalFinanceApp.Api.Features.Transfers.Common;

namespace PersonalFinanceApp.Api.Features.Transfers.GetTransferById;

public static class GetTransferById
{
    public record Query(int Id) : IQuery<TransferResponse>;

    internal sealed class Handler(
        IApplicationDbContext context,
        IUserContext userContext)
        : IQueryHandler<Query, TransferResponse>
    {
        public async Task<Result<TransferResponse>> Handle(Query query, CancellationToken cancellationToken)
        {
            Transfer existingTransfer = await context.Transfers
                .Include(t => t.OriginAccount)
                .ThenInclude(t=>t.Users)
                .Include(t => t.DestinationAccount)
                .ThenInclude(t=>t.Users)
                .AsNoTracking()
                .Where(t => t.Id == query.Id)
                .SingleOrDefaultAsync(cancellationToken);
            if (existingTransfer == null)
            {
                return Result.Failure<TransferResponse>(TransferErrors.NotFound(query.Id));
            }

            if (existingTransfer.OriginAccount.Users.FirstOrDefault(u=> u.Id.Equals(userContext.UserId, StringComparison.Ordinal)) ==null ||
                existingTransfer.DestinationAccount.Users.FirstOrDefault(u => u.Id.Equals(userContext.UserId, StringComparison.Ordinal)) == null)
            {
                return Result.Failure<TransferResponse>(TransferErrors.Unauthorized());
            }

            return new TransferResponse
            {
                Id = existingTransfer.Id,
                OriginAccountId = existingTransfer.OriginAccountId,
                DestinationAccountId = existingTransfer.DestinationAccountId,
                Amount = existingTransfer.Amount,
                Description= existingTransfer.Description
            };
        }
    }

    public sealed class Endpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet(EndpointsBase.TransfersBasePath + "/{transferId}", async (
                int accountId,
                [FromServices] IQueryHandler<Query, TransferResponse> handler,
                CancellationToken cancellationToken
                ) =>
            {
                var query = new Query(accountId);

                Result<TransferResponse> result = await handler.Handle(query, cancellationToken);

                return result.Match(Results.Ok, CustomResults.Problem);

            })
            .Produces<TransferResponse>(StatusCodes.Status200OK)
            .RequireAuthorization()
            .WithTags(Tags.Transfers);

        }
    }
}
