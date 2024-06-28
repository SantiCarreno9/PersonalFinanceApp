using BlazorWasmAuth.Identity;
using Microsoft.AspNetCore.Components;
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

        protected override void OnInitialized()
        {
            base.OnInitialized();
            LoginModel ??= new();
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
                NavigationManager.NavigateTo("transactions");
            }
            else
            {
                errors = true;
                errorList = result.ErrorList;
            }
        }
    }
}
