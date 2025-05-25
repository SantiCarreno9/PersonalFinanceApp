using System.Net;
using System.Net.Http.Json;

namespace PersonalFinanceApp.Web.Services
{
    public abstract class BaseService
    {
        protected readonly HttpClient _httpClient;
        protected readonly ILogger _logger;

        public BaseService(HttpClient httpClient, ILogger logger)
        {
            this._httpClient = httpClient;
            _logger = logger;
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
                    _logger.LogError(message);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return default;
        }

        protected async Task<HttpResponseMessage?> BaseRequest(Task<HttpResponseMessage> request)
        {
            try
            {
                var response = await request;
                if (!response.IsSuccessStatusCode)
                    _logger.LogError($"Request failed with status code: {response.StatusCode} and Content {response.Content.ReadAsStringAsync()}");

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return default;
        }

        protected async Task<T?> Get<T>(string uri, HttpStatusCode validStatusCode = HttpStatusCode.OK)
        {
            return await BaseRequest<T>(_httpClient.GetAsync(uri), validStatusCode);
        }

        protected async Task<T?> Post<T>(string uri, object body, HttpStatusCode validStatusCode = HttpStatusCode.Created)
        {
            return await BaseRequest<T>(_httpClient.PostAsJsonAsync(uri, body), validStatusCode);
        }

        protected async Task<T?> Put<T>(string uri, object body, HttpStatusCode validStatusCode = HttpStatusCode.OK)
        {
            return await BaseRequest<T>(_httpClient.PutAsJsonAsync(uri, body), validStatusCode);
        }

        protected async Task<T?> Delete<T>(string uri, HttpStatusCode validStatusCode = HttpStatusCode.NoContent)
        {
            return await BaseRequest<T>(_httpClient.DeleteAsync(uri), validStatusCode);
        }
    }
}
