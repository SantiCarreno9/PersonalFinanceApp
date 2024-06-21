using BaseLibrary.DTOs;
using PersonalFinanceApp.Web.Services.Contracts;
using System.Net.Http.Json;

namespace PersonalFinanceApp.Web.Services.Implementations
{
    public class TransactionService : ITransactionService
    {
        private readonly HttpClient _httpClient;
        private const string ApiURI = "/api/transactions";

        public TransactionService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
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

        public async Task<IEnumerable<TransactionDTO>?> GetTransactions()
        {
            try
            {
                var response = await _httpClient.GetAsync(ApiURI);
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                        return null;

                    return await response.Content.ReadFromJsonAsync<IEnumerable<TransactionDTO>>();
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
