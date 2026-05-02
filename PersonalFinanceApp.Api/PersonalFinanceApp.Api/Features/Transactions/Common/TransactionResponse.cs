using PersonalFinanceApp.Api.Entities;

namespace PersonalFinanceApp.Api.Features.Transactions.Common;

public record TransactionResponse
{
    public long Id { get; set; }
    public int AccountId { get; set; }
    public string Location { get; set; }
    public TransactionType Type { get; set; }
    public Category Category { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public DateOnly Date { get; set; }
    public decimal TotalAmount { get; set; }

    public List<TransactionDetail> TransactionDetails { get; set; }
}
