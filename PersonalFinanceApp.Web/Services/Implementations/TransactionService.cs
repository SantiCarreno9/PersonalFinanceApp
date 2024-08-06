using BaseLibrary.DTOs;
using BaseLibrary.Helper;
using BaseLibrary.Helper.GET;
using BaseLibrary.Helper.GET.Response;
using Microsoft.Extensions.Caching.Memory;
using PersonalFinanceApp.Web.Services.Contracts;
using System.Net;

namespace PersonalFinanceApp.Web.Services.Implementations
{
    public class TransactionService : BaseService, ITransactionService
    {
        private const string ApiURI = "/api/transactions";
        private readonly IMemoryCache _cache;

        public TransactionService(HttpClient httpClient, IMemoryCache cache) : base(httpClient)
        {
            this._cache = cache;
            //_httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "CfDJ8PNQSzE1fyBMqIu-TxkRXjGKKk874Oi2JsqpKS8ut0-LxCv8YaGiZar2UXTRbYDa8H-41rJcxXRnNZCw72JuTIRXlAJfbebIY_naXCxeltlUZV9b2q5ZfVrNamiXRpfVnoUIF1Qt7T0RoxoQXTNy7hczHSqYUDUxwLNMpM0Cz-RMsQL8pzXZWrgGm_L1npaujoLLWjmQhqvkxOKHfbrfQU_AXv35a0aGjlFWvaeDLMMrlcUr-Yi2WzlC9UzJGJ1_ECQzCDGOTrSG0Qs6YBIlfrm-8wqf_pbVHSOpLiSBotXBi488taBQ0o-Fz-zo9R59Gv8qd7UT7gCpx7_DyoAXIEvU3m9v75nM3rai4YTWuG-Lvaifee4XifTFcH8QzDv4X7eIgMnOIF9sojJ5fmCW6UZxW1jRtoA2y_ggObpdbjf7Kyhnfc54ZtDyXd3IjRoQWhxNJUF3GZ7MszZAVV3W3P2X5kFewi0TRnlYJyoWTxjKp0SPQPzmawdNQUcQw697JkQvIr1AWweglC4WPTvB5XzrmGGuSjplok4OIe0WqwIVvkHobFhoHnUyYgtDDMfmp2FLFI8YeOzWUzGXUFiRSqOCKQYJ1RZwTBFkYaLThpDjmnWwhBb9_ycJuRmwY-T12_QCBtqVZkI6lfFQsQYBia444bJrdSrVZhuPZJbiHspt1FCfYaK8XaR7eNSxX0iXOCi5-8SuixK3pEbikwq27-XG2B_04foABZ3e5gfSfOh8");
        }

        public async Task<TransactionDTO?> GetTransaction(long id)
        {
            return await Get<TransactionDTO?>($"{ApiURI}/{id}");
        }

        private string AddFiltersToQuery(TransactionsFiltersDTO filters, string query)
        {
            if (filters.TransactionTypeId != null) query += $"&transactionTypeId={filters.TransactionTypeId}";
            if (filters.StartDate != null) query += $"&startDate={filters.StartDate}";
            if (filters.EndDate != null) query += $"&endDate={filters.EndDate}";
            if (filters.Description != null) query += $"&description={filters.Description}";
            if (filters.Location != null) query += $"&location={filters.Location}";
            if (filters.MinAmount != null) query += $"&minAmount={filters.MinAmount}";
            if (filters.MaxAmount != null) query += $"&maxAmount={filters.MaxAmount}";
            if (filters.CategoriesIds != null)
                for (int i = 0; i < filters.CategoriesIds.Length; i++)
                    query += "&categoriesIds=" + filters.CategoriesIds[i];
            if (filters.PaymentMethodsIds != null)
                for (int i = 0; i < filters.PaymentMethodsIds.Length; i++)
                    query += "&paymentMethodsIds=" + filters.PaymentMethodsIds[i];

            return query;
        }

        public async Task<PagedList<TransactionDTO>?> GetTransactions(GetTransactionsRequestHelper request)
        {
            string query = ApiURI + "?";
            query += $"page={request.Page}";
            query += $"&pageSize={request.PageSize}";
            if (request.SortColumn != null) query += $"&sortColumn={request.SortColumn}";
            if (request.SortOrder != null) query += $"&sortOrder={request.SortOrder}";
            query = AddFiltersToQuery(request, query);

            return await Get<PagedList<TransactionDTO>?>(query);
        }

        public async Task<TransactionDTO?> CreateTransaction(TransactionDTO transactionDTO)
        {
            return await Post<TransactionDTO?>(ApiURI, transactionDTO);
        }

        public async Task<TransactionDTO?> UpdateTransaction(TransactionDTO transactionDTO)
        {
            return await Put<TransactionDTO?>($"{ApiURI}/{transactionDTO.Id}", transactionDTO);
        }

        public async Task<bool> DeleteTransactions(IEnumerable<long> ids)
        {
            string query = $"{ApiURI}?";
            foreach (long id in ids)
                query += $"id={id}&";

            var response = await BaseRequest(_httpClient.DeleteAsync(query));
            return response?.StatusCode == HttpStatusCode.NoContent;
        }

        public async Task<IEnumerable<string>?> GetLocations()
        {
            var cacheKey = "locations";
            if (!_cache.TryGetValue(cacheKey, out IEnumerable<string>? locations))
            {
                locations = await Get<IEnumerable<string>?>(ApiURI + "/locations/");
                _cache.Set(cacheKey, locations);
            }
            return locations;            
        }

        public async Task<PagedList<Summary>?> GetSummaryByProperty(GetSummaryByProperty request)
        {
            string query = ApiURI + "/summary?";
            query += $"page={request.Page}";
            query += $"&pageSize={request.PageSize}";
            query += $"&startDate={request.StartDate}";
            query += $"&endDate={request.EndDate}";
            query += $"&transactionTypeId={request.TransactionTypeId}";
            query += $"&property={request.Property}";
            if (request.SortProperty != null) query += $"&sortProperty={request.SortProperty}";
            if (request.SortOrder != null) query += $"&sortOrder={request.SortOrder}";

            return await Get<PagedList<Summary>?>(query);
        }

        public async Task<decimal?> GetTotal(TransactionsFiltersDTO request)
        {
            string query = ApiURI + "/total?";
            query = AddFiltersToQuery(request, query);

            return await Get<decimal?>(query);
        }

        public async Task<decimal?> GetBalance(TransactionsFiltersDTO request)
        {
            string query = ApiURI + "/balance?";
            query = AddFiltersToQuery(request, query);

            return await Get<decimal?>(query);
        }

        public async Task<TransactionDTO?> GetBoundTransactionByProperty(GetBoundTransaction request)
        {
            string query = ApiURI + "/bound?";
            query += $"property={request.Property}";
            query += $"&position={request.Position}";
            if (request.Value != null) query += $"&value={request.Value}";
            if (request.Id != null) query += $"&id={request.Id}";
                       
            return await Get<TransactionDTO?>(query);
        }
    }
}
