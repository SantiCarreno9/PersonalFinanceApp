namespace PersonalFinanceApp.Api.Entities;

public class TransactionDetail
{
    public long Id { get; set; }
    public long TransactionId { get; set; }
    public Category Category { get; set; }
    public string? Description { get; set; }
    public decimal Amount { get; set; }

    public Transaction Transaction { get; set; }
}
