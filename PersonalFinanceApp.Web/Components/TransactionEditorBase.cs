using BaseLibrary.DTOs;
using BaseLibrary.Entities;
using Microsoft.AspNetCore.Components;
using PersonalFinanceApp.Web.Services.Contracts;

namespace PersonalFinanceApp.Web.Components
{
    public class TransactionEditorBase : CustomBase
    {
        [Inject]
        public ILogger<TransactionEditor> Logger { get; set; }
        [Inject]
        public required ITransactionService TransactionService { get; set; }

        [Parameter]
        public TransactionDTO? Transaction { get; set; }
        [Parameter]
        public Action<TransactionDTO>? OnSuccessfullySubmitted { get; set; }
        [Parameter]
        public Action<TransactionDTO>? OnSuccessfullyUpdated { get; set; }
        [Parameter]
        public Action? OnCancel { get; set; }

        [SupplyParameterFromForm]
        public TransactionDTO? TransactionForm { get; set; }

        protected IEnumerable<string>? locations { get; set; }

        protected IEnumerable<Category>? categoriesByTransactionType { get; set; }
        protected TransactionTypes transactionType = TransactionTypes.Expense;

        protected bool isEditingExistingTransaction = false;
        protected bool isLoading = false;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            TransactionForm = new();
            TransactionForm.Date = DateTime.Today;
            TransactionForm.TransactionDetails = [new TransactionDetailDTO()];
            locations = await TransactionService.GetLocations();
            OnTransactionTypeChanged((byte)TransactionTypes.Expense);
        }

        protected override Task OnParametersSetAsync()
        {
            if (Transaction != null)
            {
                TransactionForm!.Id = Transaction.Id;
                TransactionForm.TransactionTypeId = Transaction.TransactionTypeId;
                TransactionForm.Date = Transaction.Date;
                TransactionForm.PaymentMethodId = Transaction.PaymentMethodId;
                TransactionForm.CategoryId = Transaction.CategoryId;
                TransactionForm.TotalAmount = Transaction.TotalAmount;
                TransactionForm.Location = Transaction.Location;
                TransactionForm.TransactionDetails = Transaction.TransactionDetails;
                isEditingExistingTransaction = true;
            }
            else
            {
                TransactionForm = new();                
                TransactionForm.Date = DateTime.Today.ToLocalTime();
                TransactionForm.TransactionDetails = [new TransactionDetailDTO()];
                isEditingExistingTransaction = false;                
            }
            OnTransactionTypeChanged(TransactionForm.TransactionTypeId);
            return base.OnParametersSetAsync();
        }

        protected async Task Submit()
        {
            if (TransactionForm == null)
                return;

            isLoading = true;
            if (isEditingExistingTransaction)
            {
                await TransactionService.UpdateTransaction(TransactionForm);
                isLoading = false;
                OnSuccessfullyUpdated?.Invoke(TransactionForm);
            }                
            else
            {
                await TransactionService.CreateTransaction(TransactionForm);
                isLoading = false;
                OnSuccessfullySubmitted?.Invoke(TransactionForm);
            }                                        
        }

        public void Cancel()
        {
            isLoading = false;
            OnCancel?.Invoke();
        }

        protected void OnTransactionTypeChanged(byte transactionTypes)
        {
            TransactionForm!.TransactionTypeId = transactionTypes;
            categoriesByTransactionType = Categories.Values
                .Where(c => (c.TransactionTypeId != null && c.TransactionTypeId.Value == transactionTypes))
                .ToList();

            StateHasChanged();
        }

        protected void OnDetailAmountChanged(TransactionDetailDTO detail, decimal amount)
        {
            detail.Amount = amount;
            TransactionForm!.TotalAmount = 0;
            foreach (var item in TransactionForm!.TransactionDetails)
                TransactionForm!.TotalAmount += item.Amount;
        }
    }
}
