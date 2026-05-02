namespace PersonalFinanceApp.Api.Entities;

public class Transaction
{
    public long Id { get; set; }
    public int AccountId { get; set; }
    public string Location { get; set; }
    public TransactionType Type { get; set; }
    public Category Category { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public DateOnly Date { get; set; }
    public decimal TotalAmount { get; set; }

    public IList<TransactionDetail> TransactionDetails { get; set; }
}
