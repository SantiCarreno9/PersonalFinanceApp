using BaseLibrary.DTOs;
using BaseLibrary.Entities;
using Microsoft.AspNetCore.Components;
using PersonalFinanceApp.Web.Services.Contracts;

namespace PersonalFinanceApp.Web.Components
{
    public partial class TransactionEditor : ComponentBase
    {
        [Inject]
        public ILogger<TransactionEditor> Logger { get; set; }
        [Inject]
        public required ICategoryService CategoryService { get; set; }
        [Inject]
        public required ITransactionService TransactionService { get; set; }

        [Parameter]
        public Action<TransactionDTO>? OnSuccessfullySubmitted { get; set; }

        [SupplyParameterFromForm]
        public TransactionDTO? Transaction { get; set; }

        private IEnumerable<Category>? Categories { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Transaction ??= new();
            Categories = await CategoryService.GetCategories();
        }        

        private async Task Submit()
        {
            if (Transaction == null)
                return;
            await TransactionService.CreateTransaction(Transaction);
            Logger.LogInformation("Submitted");
            OnSuccessfullySubmitted?.Invoke(Transaction);
        }
    }
}
