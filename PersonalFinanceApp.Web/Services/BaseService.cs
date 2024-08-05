using System.Net;
using System.Net.Http.Json;

namespace PersonalFinanceApp.Web.Services
{
    public abstract class BaseService
    {
        protected readonly HttpClient _httpClient;

        public BaseService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        protected async Task<T?> BaseRequest<T>(Task<HttpResponseMessage> request, HttpStatusCode validStatusCode)
        {
            try
            {
                var response = await request;
                if (response.IsSuccessStatusCode)
                {                    
                    if (response.StatusCode != validStatusCode)
                        return default;

                    return await response.Content.ReadFromJsonAsync<T>();
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

        protected async Task<HttpResponseMessage?> BaseRequest(Task<HttpResponseMessage> request)
        {
            try
            {
                var response = await request;
                if (response.IsSuccessStatusCode)                
                    return response;                
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

        protected async Task<T?> Get<T>(string uri, HttpStatusCode validStatusCode = HttpStatusCode.OK)
        {
            return await BaseRequest<T>(_httpClient.GetAsync(uri), validStatusCode);
        }

        protected async Task<T?> Post<T>(string uri, object body, HttpStatusCode validStatusCode = HttpStatusCode.Created)
        {
            return await BaseRequest<T>(_httpClient.PostAsJsonAsync(uri,body), validStatusCode);
        }

        protected async Task<T?> Put<T>(string uri, object body, HttpStatusCode validStatusCode = HttpStatusCode.OK)
        {
            return await BaseRequest<T>(_httpClient.PutAsJsonAsync(uri,body), validStatusCode);
        }

        protected async Task<T?> Delete<T>(string uri, HttpStatusCode validStatusCode = HttpStatusCode.NoContent)
        {
            return await BaseRequest<T>(_httpClient.DeleteAsync(uri), validStatusCode);
        }
    }
}
