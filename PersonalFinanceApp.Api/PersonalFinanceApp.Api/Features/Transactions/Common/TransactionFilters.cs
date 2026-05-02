using PersonalFinanceApp.Api.Entities;

namespace PersonalFinanceApp.Api.Features.Transactions.Common;

public class TransactionFilters
{
    public TransactionType? Type { get; set; }
    public DateOnly? StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public string? Description { get; set; }
    public string? Location { get; set; }
    public decimal? MinAmount { get; set; }
    public decimal? MaxAmount { get; set; }
    public Category[]? Categories { get; set; }
    public PaymentMethod[]? PaymentMethods { get; set; }
}
