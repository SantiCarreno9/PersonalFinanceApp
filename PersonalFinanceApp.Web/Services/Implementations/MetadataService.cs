using BaseLibrary.Entities;
using Microsoft.Extensions.Caching.Memory;
using PersonalFinanceApp.Web.Services.Contracts;

namespace PersonalFinanceApp.Web.Services.Implementations
{
    public class MetadataService : BaseService, IMetadataService
    {
        private const string ApiURI = "/api/metadata";
        private readonly IMemoryCache _cache;

        public MetadataService(HttpClient httpClient, IMemoryCache cache) : base(httpClient)
        {
            this._cache = cache;
        }

        #region CATEGORIES

        public async Task<Category?> GetCategory(int id)
        {
            return await Get<Category?>($"{ApiURI}/categories/{id}");
        }

        public async Task<IEnumerable<Category>?> GetCategories()
        {
            var cacheKey = "categories";
            if (!_cache.TryGetValue(cacheKey, out IEnumerable<Category>? categories))
            {
                categories = await Get<IEnumerable<Category>?>(ApiURI + "/categories/");
                _cache.Set(cacheKey, categories);
            }
            return categories;
        }

        #endregion

        #region TRANSACTION TYPES

        public async Task<IEnumerable<TransactionType>?> GetTransactionTypes()
        {
            var cacheKey = "transactionTypes";
            if (!_cache.TryGetValue(cacheKey, out IEnumerable<TransactionType>? transactionTypes))
            {
                transactionTypes = await Get<IEnumerable<TransactionType>?>(ApiURI + "/transactionTypes/");
                _cache.Set(cacheKey, transactionTypes);
            }
            return transactionTypes;            
        }

        public async Task<TransactionType?> GetTransactionType(int id)
        {            
            return await Get<TransactionType?>($"{ApiURI}/transactionTypes/{id}");            
        }

        #endregion

        #region PAYMENT METHODS

        public async Task<IEnumerable<PaymentMethod>?> GetPaymentMethods()
        {
            var cacheKey = "paymentMethods";
            if (!_cache.TryGetValue(cacheKey, out IEnumerable<PaymentMethod>? paymentMethods))
            {
                paymentMethods = await Get<IEnumerable<PaymentMethod>?>(ApiURI + "/paymentMethods/");
                _cache.Set(cacheKey, paymentMethods);                
            }
            return paymentMethods;
        }

        public async Task<PaymentMethod?> GetPaymentMethod(int id)
        {
            return await Get<PaymentMethod?>($"{ApiURI}/paymentMethods/{id}");            
        }

        #endregion
    }
}
