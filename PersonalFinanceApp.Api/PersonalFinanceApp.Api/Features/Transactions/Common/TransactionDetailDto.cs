using PersonalFinanceApp.Api.Entities;

namespace PersonalFinanceApp.Api.Features.Transactions.Common;

public record TransactionDetailDto(
    Category Category,
    string Description,
    decimal Amount);
