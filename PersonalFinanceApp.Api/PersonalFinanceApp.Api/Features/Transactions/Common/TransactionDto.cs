using PersonalFinanceApp.Api.Entities;

namespace PersonalFinanceApp.Api.Features.Transactions.Common;

public record TransactionDto(
        int AccountId,
        string Location,
        PaymentMethod PaymentMethod,
        Category Category,
        DateOnly Date,
        decimal TotalAmount,
        List<TransactionDetailDto> TransactionDetails);
