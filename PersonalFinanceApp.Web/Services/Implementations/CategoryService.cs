using BaseLibrary.Entities;
using PersonalFinanceApp.Web.Services.Contracts;
using System.Net.Http.Json;

namespace PersonalFinanceApp.Web.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;
        private const string ApiURI = "/api/categories";

        public CategoryService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<Category?> GetCategory(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{ApiURI}/{id}");
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
            try
            {
                var response = await _httpClient.GetAsync(ApiURI);
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                        return null;
                    
                    return await response.Content.ReadFromJsonAsync<IEnumerable<Category>>();
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
