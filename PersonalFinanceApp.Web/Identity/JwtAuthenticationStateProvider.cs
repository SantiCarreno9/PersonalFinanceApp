using BlazorWasmAuth.Identity;
using BlazorWasmAuth.Identity.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace PersonalFinanceApp.Web.Identity
{
    public class JwtAuthenticationStateProvider : AuthenticationStateProvider, IAccountManagement
    {
        /// <summary>
        /// Map the JavaScript-formatted properties to C#-formatted classes.
        /// </summary>
        private readonly JsonSerializerOptions jsonSerializerOptions =
            new()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

        /// <summary>
        /// Special auth client.
        /// </summary>
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Authentication state.
        /// </summary>
        private bool _authenticated = false;

        /// <summary>
        /// Default principal for anonymous (not authenticated) users.
        /// </summary>
        private readonly ClaimsPrincipal Unauthenticated =
            new(new ClaimsIdentity());

        private IJSRuntime _jsRuntime;

        private readonly string _accessTokenName = "AccessToken";
        private readonly string _refreshTokenName = "RefreshToken";

        //Injects the instance created when running the app so the auth header stay accross the whole app
        public JwtAuthenticationStateProvider(HttpClient httpClient, IJSRuntime jsRuntime)
        {
            _httpClient = httpClient;
            _jsRuntime = jsRuntime;            
        }

        /// <summary>
        /// Register a new user.
        /// </summary>
        /// <param name="email">The user's email address.</param>
        /// <param name="password">The user's password.</param>
        /// <returns>The result serialized to a <see cref="FormResult"/>.
        /// </returns>
        public async Task<FormResult> RegisterAsync(string email, string password)
        {
            string[] defaultDetail = ["An unknown error prevented registration from succeeding."];

            try
            {
                // make the request
                var result = await _httpClient.PostAsJsonAsync(
                    "register", new
                    {
                        email,
                        password
                    });

                // successful?
                if (result.IsSuccessStatusCode)
                {
                    return new FormResult { Succeeded = true };
                }

                // body should contain details about why it failed
                var details = await result.Content.ReadAsStringAsync();
                var problemDetails = JsonDocument.Parse(details);
                var errors = new List<string>();
                var errorList = problemDetails.RootElement.GetProperty("errors");

                foreach (var errorEntry in errorList.EnumerateObject())
                {
                    if (errorEntry.Value.ValueKind == JsonValueKind.String)
                    {
                        errors.Add(errorEntry.Value.GetString()!);
                    }
                    else if (errorEntry.Value.ValueKind == JsonValueKind.Array)
                    {
                        errors.AddRange(
                            errorEntry.Value.EnumerateArray().Select(
                                e => e.GetString() ?? string.Empty)
                            .Where(e => !string.IsNullOrEmpty(e)));
                    }
                }

                // return the error list
                return new FormResult
                {
                    Succeeded = false,
                    ErrorList = problemDetails == null ? defaultDetail : [.. errors]
                };
            }
            catch { }

            // unknown error
            return new FormResult
            {
                Succeeded = false,
                ErrorList = defaultDetail
            };
        }

        /// <summary>
        /// User login.
        /// </summary>
        /// <param name="email">The user's email address.</param>
        /// <param name="password">The user's password.</param>
        /// <returns>The result of the login request serialized to a <see cref="FormResult"/>.</returns>
        public async Task<FormResult> LoginAsync(string email, string password)
        {
            try
            {
                // login with cookies
                var result = await _httpClient.PostAsJsonAsync(
                    "login", new
                    {
                        email,
                        password
                    });


                // success?
                if (result.IsSuccessStatusCode)
                {
                    var token = await result.Content.ReadFromJsonAsync<TokenResponse>();
                    if (token != null)
                    {
                        await StoreTokensInLocalStorage(token);
                    }

                    // need to refresh auth state
                    NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());

                    // success!
                    return new FormResult { Succeeded = true };
                }
            }
            catch { }

            // unknown error
            return new FormResult
            {
                Succeeded = false,
                ErrorList = ["Invalid email and/or password."]
            };
        }

        public async Task<FormResult> LoginAsGuestAsync()
        {
            try
            {
                Console.WriteLine("Trying to login");
                // login with cookies
                var result = await _httpClient.PostAsJsonAsync(
                    "login-as-guest", "");

                //Console.WriteLine("Login result: {result}", result.StatusCode);
                // success?
                if (result.IsSuccessStatusCode)
                {

                    var token = await result.Content.ReadFromJsonAsync<TokenResponse>();
                    if (token != null)
                    {
                        await StoreTokensInLocalStorage(token);
                    }
                    // need to refresh auth state
                    NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());

                    // success!
                    return new FormResult { Succeeded = true };
                }
            }
            catch { }

            // unknown error
            return new FormResult
            {
                Succeeded = false,
                ErrorList = ["Unexpected Error"]
            };
        }

        public async Task<FormResult> RefreshLoginAsync(string token)
        {
            try
            {
                var body = new
                {
                    refreshToken = token
                };
                // login with cookies
                var result = await _httpClient.PostAsJsonAsync(
                    "refresh", body);

                // success?
                if (result.IsSuccessStatusCode)
                {
                    var newToken = await result.Content.ReadFromJsonAsync<TokenResponse>();
                    if (newToken != null)
                    {
                        await StoreTokensInLocalStorage(newToken);
                    }
                    // need to refresh auth state
                    NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());

                    // success!
                    return new FormResult { Succeeded = true };
                }
            }
            catch { }

            // unknown error
            return new FormResult
            {
                Succeeded = false,
                ErrorList = ["Unexpected Error"]
            };
        }

        private async Task StoreTokensInLocalStorage(TokenResponse tokenResponse)
        {
            await StoreTokenInfo(_accessTokenName, tokenResponse.AccessToken);
            await StoreTokenInfo(_refreshTokenName, tokenResponse.RefreshToken);
        }

        private async Task<bool> TrySetAuthenticationHeader()
        {
            string accessToken = await TryGetTokenFromLocalStorage();
            if (accessToken == null)
                return false;

            _httpClient.DefaultRequestHeaders.Authorization = new
                    System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            return true;
        }

        private async Task StoreTokenInfo(string tokenName, string tokenSecret)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", tokenName, tokenSecret);
        }

        private async Task<string> GetTokenInfo(string tokenName)
        {
            return await _jsRuntime.InvokeAsync<string>("localStorage.getItem", tokenName);
        }

        private async Task RemoveTokenInfo(string tokenName)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", tokenName);
        }

        private async Task<string> TryGetTokenFromLocalStorage()
        {
            return await GetTokenInfo(_accessTokenName);
        }

        /// <summary>
        /// Get authentication state.
        /// </summary>
        /// <remarks>
        /// Called by Blazor anytime and authentication-based decision needs to be made, then cached
        /// until the changed state notification is raised.
        /// </remarks>
        /// <returns>The authentication state asynchronous request.</returns>
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            _authenticated = false;

            // default to not authenticated
            var user = Unauthenticated;

            try
            {
                await TrySetAuthenticationHeader();
                // the user info endpoint is secured, so if the user isn't logged in this will fail
                var userResponse = await _httpClient.GetAsync("manage/info");

                // throw if user info wasn't retrieved
                userResponse.EnsureSuccessStatusCode();

                // user is authenticated,so let's build their authenticated identity
                var userJson = await userResponse.Content.ReadAsStringAsync();
                var userInfo = JsonSerializer.Deserialize<UserInfo>(userJson, jsonSerializerOptions);

                if (userInfo != null)
                {
                    // in our system name and email are the same
                    var claims = new List<Claim>
                    {
                        new(ClaimTypes.Name, userInfo.Email),
                        new(ClaimTypes.Email, userInfo.Email)
                    };

                    // add any additional claims
                    claims.AddRange(
                        userInfo.Claims.Where(c => c.Key != ClaimTypes.Name && c.Key != ClaimTypes.Email)
                            .Select(c => new Claim(c.Key, c.Value)));

                    // set the principal
                    var id = new ClaimsIdentity(claims, nameof(CookieAuthenticationStateProvider));
                    user = new ClaimsPrincipal(id);
                    _authenticated = true;
                }
            }
            catch (Exception ex)
            {

                //if (ex is HttpRequestException)
                //{
                //    string refreshToken = await GetTokenInfo(_refreshTokenName);
                //    if (refreshToken != null)
                //    {
                //        await RefreshLoginAsync(refreshToken);
                //    }
                //}
            }

            // return the state
            return new AuthenticationState(user);
        }

        public async Task LogoutAsync()
        {
            const string Empty = "{}";
            var emptyContent = new StringContent(Empty, Encoding.UTF8, "application/json");
            var result = await _httpClient.PostAsync("logout", emptyContent);
            if (result.IsSuccessStatusCode)
            {
                _httpClient.DefaultRequestHeaders.Authorization = null;
                await RemoveTokenInfo(_accessTokenName);
                await RemoveTokenInfo(_refreshTokenName);
            }
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public async Task<bool> CheckAuthenticatedAsync()
        {
            await GetAuthenticationStateAsync();
            return _authenticated;
        }

        class TokenResponse
        {
            public string TokenType { get; set; }
            public string AccessToken { get; set; }
            public string RefreshToken { get; set; }
        }
    }
}
