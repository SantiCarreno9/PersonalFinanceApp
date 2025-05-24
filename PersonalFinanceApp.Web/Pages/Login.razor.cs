using BlazorWasmAuth.Identity;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using PersonalFinanceApp.Web.Models;
using System.Net.Http.Json;

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

        [SupplyParameterFromForm]
        public LoginModel? LoginModel { get; set; }

        private string[] errorList = [];
        private bool success, errors;
        private bool isLoading = false;

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

            isLoading = true;
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
            isLoading = false;
        }

        private async Task LoginAsAGuest()
        {
            isLoading = true;
            var result = await AccountManagement.LoginAsGuestAsync();

            if(result.Succeeded)
            {
                success = true;
                NavigationManager.NavigateTo("dashboard");                
            }
            else
            {
                errors = true;
                errorList = result.ErrorList;                
            }
            isLoading = false;
        }
    }
}
