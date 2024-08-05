using BlazorWasmAuth.Identity;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using PersonalFinanceApp.Web.Models;

namespace PersonalFinanceApp.Web.Pages
{
    public partial class Login : ComponentBase
    {
        [Inject]
        public IAccountManagement AccountManagement { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

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
    }
}
