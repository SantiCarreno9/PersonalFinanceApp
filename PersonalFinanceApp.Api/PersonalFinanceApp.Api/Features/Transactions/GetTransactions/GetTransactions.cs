//using BaseLibrary.Helper;
//using PersonalFinanceApp.Api.Core.Abstractions.Messaging;
//using PersonalFinanceApp.Api.Core.Endpoints;
//using PersonalFinanceApp.Api.Database;
//using PersonalFinanceApp.Api.Features.Transactions.Common;

//namespace PersonalFinanceApp.Api.Features.Transactions.GetTransactions;

//public static class GetTransactions
//{
//    public record Query():IQuery<PagedList<TransactionResponse>>;

//    internal sealed class Handler(IApplicationDbContext context) : IQueryHandler<Query, PagedList<TransactionResponse>>
//    {
//        public Task<Result<PagedList<TransactionResponse>>> Handle(Query query, CancellationToken cancellationToken)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
