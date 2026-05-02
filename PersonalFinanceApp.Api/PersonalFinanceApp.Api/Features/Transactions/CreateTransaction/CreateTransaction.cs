//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using PersonalFinanceApp.Api.Core.Abstractions.Authentication;
//using PersonalFinanceApp.Api.Core.Abstractions.Messaging;
//using PersonalFinanceApp.Api.Core.Endpoints;
//using PersonalFinanceApp.Api.Database;
//using PersonalFinanceApp.Api.Entities;
//using PersonalFinanceApp.Api.Features.Transactions.Common;

//namespace PersonalFinanceApp.Api.Features.Transactions.CreateTransaction;

//public static class CreateTransaction
//{
//    public record CreateTransactionCommand(
//        int AccountId,
//        string Location,
//        PaymentMethod PaymentMethod,
//        Category Category,
//        DateOnly Date,
//        decimal TotalAmount,
//        IList<TransactionDetailDto> TransactionDetails) : ICommand<TransactionResponse>;

//    internal sealed class Handler(IApplicationDbContext context, IUserContext userContext) : ICommandHandler<CreateTransactionCommand, TransactionResponse>
//    {
//        public async Task<Result<TransactionResponse>> Handle(CreateTransactionCommand command, CancellationToken cancellationToken)
//        {
//            //TransactionDetail
//            var transaction = new Transaction
//            {
//                AccountId = command.AccountId,
//                Date = command.Date,
//                Location = command.Location,
//                PaymentMethod = command.PaymentMethod,
//                Category = command.Category,
//                TotalAmount = command.TotalAmount
//            };
//            TransactionResponse? response = await context.Transactions
//                .Where(t => t.AccountId == command.AccountId /*&& t.Id == command.TransactionId*/)
//                .Include(t => t.TransactionDetails)
//                .Select(t => new TransactionResponse
//                {
//                    Id = t.Id,
//                    AccountId = t.AccountId,
//                    Location = t.Location,
//                    Category = t.Category,
//                    Type = t.Type,
//                    PaymentMethod = t.PaymentMethod,
//                    Date = t.Date,
//                    TotalAmount = t.TotalAmount,
//                    //TransactionDetails = t.TransactionDetails
//                })
//                .AsNoTracking()
//                .SingleOrDefaultAsync(cancellationToken);

//            return response;
//        }
//    }

//    public sealed class Endpoint : IEndpoint
//    {
//        public void MapEndpoint(IEndpointRouteBuilder app)
//        {
//            app.MapPost(EndpointsBase.TransactionsBasePath, async (
//                [FromBody] CreateTransactionCommand request,
//                [FromServices] ICommandHandler<CreateTransactionCommand, TransactionResponse> handler,
//                CancellationToken cancellationToken
//                ) =>
//            {
//                Result<TransactionResponse> result = await handler.Handle(request, cancellationToken);

//                return result.Match(Results.Ok, CustomResults.Problem);
//            })
//                .Produces<TransactionResponse>(StatusCodes.Status200OK)
//                .RequireAuthorization()
//                .WithTags(Tags.Transactions);

//        }
//    }
//}
