using BaseLibrary.Entities;
using Microsoft.Extensions.Caching.Memory;
using PersonalFinanceApp.Web.Services.Contracts;
using System.Net.Http.Json;

namespace PersonalFinanceApp.Web.Services.Implementations
{
    public class MetadataService : IMetadataService
    {
        private readonly HttpClient _httpClient;
        private const string ApiURI = "/api/metadata";
        private readonly IMemoryCache _cache;

        public MetadataService(HttpClient httpClient, IMemoryCache cache)
        {
            this._httpClient = httpClient;
            this._cache = cache;
        }

        #region CATEGORIES

        public async Task<Category?> GetCategory(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{ApiURI}/categories/{id}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                        return null;

                    return await response.Content.ReadFromJsonAsync<Category>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<Category>?> GetCategories()
        {
            var cacheKey = "categories";
            if (!_cache.TryGetValue(cacheKey, out IEnumerable<Category>? categories))
            {
                try
                {
                    var response = await _httpClient.GetAsync(ApiURI + "/categories/");
                    if (response.IsSuccessStatusCode)
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                            return null;

                        categories = await response.Content.ReadFromJsonAsync<IEnumerable<Category>>();

                        _cache.Set(cacheKey, categories);
                    }
                    else
                    {
                        var message = await response.Content.ReadAsStringAsync();
                        throw new Exception(message);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
            return categories;
        }

        #endregion

        #region TRANSACTION TYPES

        public async Task<IEnumerable<TransactionType>?> GetTransactionTypes()
        {
            try
            {
                var response = await _httpClient.GetAsync(ApiURI + "/transactionTypes/");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                        return null;

                    return await response.Content.ReadFromJsonAsync<IEnumerable<TransactionType>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<TransactionType?> GetTransactionType(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{ApiURI}/transactionTypes/{id}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                        return null;

                    return await response.Content.ReadFromJsonAsync<TransactionType>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        #endregion

        #region PAYMENT METHODS

        public async Task<IEnumerable<PaymentMethod>?> GetPaymentMethods()
        {
            var cacheKey = "paymentMethods";
            if (!_cache.TryGetValue(cacheKey, out IEnumerable<PaymentMethod>? paymentMethods))
            {
                try
                {
                    var response = await _httpClient.GetAsync(ApiURI + "/paymentMethods/");
                    if (response.IsSuccessStatusCode)
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                            return null;

                        paymentMethods = await response.Content.ReadFromJsonAsync<IEnumerable<PaymentMethod>>();

                        _cache.Set(cacheKey, paymentMethods);
                    }
                    else
                    {
                        var message = await response.Content.ReadAsStringAsync();
                        throw new Exception(message);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
            return paymentMethods;            
        }

        public async Task<PaymentMethod?> GetPaymentMethod(int id)
        {            
            try
            {
                var response = await _httpClient.GetAsync($"{ApiURI}/paymentMethods/{id}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                        return null;

                    return await response.Content.ReadFromJsonAsync<PaymentMethod>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        #endregion
    }
}
