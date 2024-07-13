using BaseLibrary.DTOs;
using BaseLibrary.Entities;
using BaseLibrary.Helper;
using BaseLibrary.Helper.GET;
using Microsoft.Extensions.Caching.Memory;
using PersonalFinanceApp.Web.Services.Contracts;
using System.Net.Http.Json;

namespace PersonalFinanceApp.Web.Services.Implementations
{
    public class TransactionService : ITransactionService
    {
        private readonly HttpClient _httpClient;
        private const string ApiURI = "/api/transactions";
        private readonly IMemoryCache _cache;

        public TransactionService(HttpClient httpClient, IMemoryCache cache)
        {
            this._httpClient = httpClient;
            this._cache = cache;
        }

        public async Task<TransactionDTO?> GetTransaction(long id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{ApiURI}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                        return null;

                    return await response.Content.ReadFromJsonAsync<TransactionDTO>();
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

        public async Task<PagedList<TransactionDTO>?> GetTransactions(GetTransactionsRequestHelper request)
        {
            try
            {
                string query = ApiURI + "?";
                query += $"page={request.Page}";
                query += $"&pageSize={request.PageSize}";
                if (request.Type != null) query += $"&type={request.Type}";
                if (request.SortColumn != null) query += $"&sortColumn={request.SortColumn}";
                if (request.SortOrder != null) query += $"&sortOrder={request.SortOrder}";                
                if (request.StartDate != null) query += $"&startDate={request.StartDate}";
                if (request.EndDate != null) query += $"&endDate={request.EndDate}";
                if (request.Description != null) query += $"&description={request.Description}";
                if (request.Location != null) query += $"&location={request.Location}";
                if (request.MinAmount != null) query += $"&minAmount={request.MinAmount}";
                if (request.MaxAmount != null) query += $"&maxAmount={request.MaxAmount}";                
                if (request.Categories != null)                
                    for (int i = 0; i < request.Categories.Length; i++)
                        query += "&categories=" + request.Categories[i];                
                if (request.PaymentMethods != null)                
                    for (int i = 0; i < request.PaymentMethods.Length; i++)
                        query += "&paymentMethods=" + request.PaymentMethods[i];                

                var response = await _httpClient.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                        return null;

                    return await response.Content.ReadFromJsonAsync<PagedList<TransactionDTO>>();
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

        public async Task<TransactionDTO?> CreateTransaction(TransactionDTO transactionDTO)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(ApiURI, transactionDTO);
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode != System.Net.HttpStatusCode.Created)
                        return null;
                    return await response.Content.ReadFromJsonAsync<TransactionDTO>();
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

        public async Task<IEnumerable<string>?> GetLocations()
        {
            try
            {
                var response = await _httpClient.GetAsync(ApiURI + "/locations");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                        return null;

                    return await response.Content.ReadFromJsonAsync<IEnumerable<string>>();
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

        public async Task<TransactionDTO?> UpdateTransaction(TransactionDTO transactionDTO)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{ApiURI}/{transactionDTO.Id}", transactionDTO);
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                        return null;
                    return await response.Content.ReadFromJsonAsync<TransactionDTO>();
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

        public async Task<bool> DeleteTransaction(long id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{ApiURI}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode != System.Net.HttpStatusCode.NoContent)
                        return false;
                    return true;
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
    }
}
