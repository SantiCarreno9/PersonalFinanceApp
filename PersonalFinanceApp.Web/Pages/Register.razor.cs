using BlazorWasmAuth.Identity;
using Microsoft.AspNetCore.Components;
using PersonalFinanceApp.Web.Models;

namespace PersonalFinanceApp.Web.Pages
{
    public partial class Register : ComponentBase
    {
        [Inject]
        public IAccountManagement AccountManagement { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [SupplyParameterFromForm]
        public RegisterModel? RegisterModel { get; set; }

        private string[] errorList = [];
        private bool success, errors;
        private string email = string.Empty;
        private string password = string.Empty;
        private string confirmPassword = string.Empty;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            RegisterModel ??= new();
        }

        private async Task Submit()
        {
            if (RegisterModel == null)
                return;
            success = errors = false;
            errorList = [];
            if (RegisterModel.Password != RegisterModel.ConfirmPassword)
            {
                errors = true;
                errorList = ["Passwords don't match."];

                return;
            }
            var result = await AccountManagement.RegisterAsync(RegisterModel!.EmailAddress, RegisterModel!.Password);

            if (result.Succeeded)
            {
                success = true;                
                NavigationManager.NavigateTo("login");
            }
            else
            {
                errors = true;
                errorList = result.ErrorList;
            }
        }
    }
}
