//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using PersonalFinanceApp.Api.Core.Abstractions.Authentication;
//using PersonalFinanceApp.Api.Core.Abstractions.Messaging;
//using PersonalFinanceApp.Api.Core.Endpoints;
//using PersonalFinanceApp.Api.Database;
//using PersonalFinanceApp.Api.Features.Transactions.Common;

//namespace PersonalFinanceApp.Api.Features.Transactions.GetTransactionById;

//public static class GetTransactionById
//{
//    public record GetTransactionByIdQuery(long TransactionId, int AccountId) : IQuery<TransactionResponse>;

//    internal sealed class Handler(IApplicationDbContext context, IUserContext userContext) : IQueryHandler<GetTransactionByIdQuery, TransactionResponse>
//    {
//        public async Task<Result<TransactionResponse>> Handle(GetTransactionByIdQuery query, CancellationToken cancellationToken)
//        {
//            //TransactionResponse? transaction = await context.Transactions
//            //    .Where(t => t.AccountId == query.AccountId && t.Id == query.TransactionId)
//            //    .Include(t => t.TransactionDetails)
//            //    .Select(t => new TransactionResponse
//            //    {
//            //        Id = t.Id,
//            //        AccountId = t.AccountId,
//            //        Location = t.Location,
//            //        Category = t.Category,
//            //        Type = t.Type,
//            //        PaymentMethod = t.PaymentMethod,
//            //        Date = t.Date,
//            //        TotalAmount = t.TotalAmount,
//            //        TransactionDetails = t.TransactionDetails
//            //    })
//            //    .AsNoTracking()
//            //    .SingleOrDefaultAsync(cancellationToken);

//            return new TransactionResponse();
//        }
//    }

//    public sealed class Endpoint : IEndpoint
//    {
//        public void MapEndpoint(IEndpointRouteBuilder app)
//        {            
//            app.MapGet(EndpointsBase.TransactionsBasePath + "/{id}", async (
//                [FromQuery] GetTransactionByIdQuery request,
//                [FromServices] IQueryHandler<GetTransactionByIdQuery, TransactionResponse> handler,
//                CancellationToken cancellationToken
//                ) =>
//            {
//                //var query = new GetTransactionByIdQuery();
//                Result<TransactionResponse> result = await handler.Handle(request, cancellationToken);

//                return result.Match(Results.Ok, CustomResults.Problem);
//            })
//                .Produces<TransactionResponse>(StatusCodes.Status200OK)
//                .RequireAuthorization()
//                .WithTags(Tags.Transactions);

//        }
//    }
//}
