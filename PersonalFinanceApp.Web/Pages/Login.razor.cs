using BlazorWasmAuth.Identity;
using BlazorWasmAuth.Identity.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using PersonalFinanceApp.Web.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PersonalFinanceApp.Web.Pages
{
    public partial class Login : ComponentBase
    {
        [Inject]
        public IAccountManagement AccountManagement { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }        
        [Inject]
        public HttpClient _httpClient { get; set; }
        [Inject]
        public IAccountManagement _accountManagement { get; set; }
        [Inject]
        public AuthenticationStateProvider _authStateProvider { get; set; }

        [SupplyParameterFromForm]
        public LoginModel? LoginModel { get; set; }

        private string[] errorList = [];
        private bool success, errors;

        protected override async Task OnInitializedAsync()
        {
            base.OnInitialized();
            LoginModel ??= new();

            if (await AccountManagement.CheckAuthenticatedAsync())
            {                
                NavigationManager.NavigateTo("dashboard");
            }
        }

        private async Task Submit()
        {
            if (LoginModel == null)
                return;
            success = errors = false;
            errorList = [];

            var result = await AccountManagement.LoginAsync(LoginModel!.EmailAddress, LoginModel!.Password);            

            if (result.Succeeded)
            {
                success = true;                
                NavigationManager.NavigateTo("dashboard");
            }
            else
            {
                errors = true;
                errorList = result.ErrorList;
            }
        }

        private async Task LoginAsAGuest()
        {           
            try
            {
                // login with cookies
                var result = await _httpClient.PostAsJsonAsync(
                    "login-as-guest?useSessionCookies=true", "");

                // success?
                if (result.IsSuccessStatusCode)
                {                    
                    await AccountManagement.CheckAuthenticatedAsync();
                    NavigationManager.Refresh();                 
                }
            }
            catch { }

            errors = true;
            errorList = ["Invalid email and/or password."];                        
        }
    }
}
