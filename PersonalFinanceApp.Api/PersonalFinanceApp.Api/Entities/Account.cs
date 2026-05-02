namespace PersonalFinanceApp.Api.Entities;

public class Account
{
    public int Id { get; set; }
    public string Name { get; set; }
    public AccountType AccountType { get; set; }
    public decimal Balance { get; set; }

    public IList<User> Users { get; set; } = [];
    public IList<Transaction> Transactions { get; set; } = [];
}
