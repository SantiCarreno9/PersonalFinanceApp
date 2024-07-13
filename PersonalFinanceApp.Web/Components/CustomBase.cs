using BaseLibrary.Entities;
using Microsoft.AspNetCore.Components;
using PersonalFinanceApp.Web.Services.Contracts;

namespace PersonalFinanceApp.Web.Components
{
    public abstract class CustomBase : ComponentBase
    {
        [Inject]
        public required IMetadataService MetadataService { get; set; }

        protected Dictionary<byte, Category> Categories = new Dictionary<byte, Category>();
        protected Dictionary<byte, PaymentMethod> PaymentMethods = new Dictionary<byte, PaymentMethod>();

        protected override async Task OnInitializedAsync()
        {
            var categories = await MetadataService.GetCategories();
            if (categories == null)
                return;

            foreach (var category in categories)
                Categories.Add(category.Id, category);

            var paymentMethods = await MetadataService.GetPaymentMethods();
            if (paymentMethods == null)
                return;

            foreach (var paymentMethod in paymentMethods)
                PaymentMethods.Add(paymentMethod.Id, paymentMethod);
        }

        protected string? GetCategoryName(byte id) => Categories[id]?.Name;
        protected string? GetPaymentMethod(byte id) => PaymentMethods[id]?.Name;
    }
}
