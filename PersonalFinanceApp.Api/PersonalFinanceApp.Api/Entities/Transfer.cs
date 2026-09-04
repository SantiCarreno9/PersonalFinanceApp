namespace PersonalFinanceApp.Api.Entities;

public class Transfer
{
    public long Id { get; set; }
    public int OriginAccountId { get; set; }
    public int DestinationAccountId { get; set; }
    public decimal Amount { get; set; }
    public string? Description { get; set; }

    public Account OriginAccount { get; set; }
    public Account DestinationAccount { get; set; }
}
