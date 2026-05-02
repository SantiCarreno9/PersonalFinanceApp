namespace PersonalFinanceApp.Api.Entities;

public class AccountUser
{
    public string Id { get; set; }
    public string UserId { get; set; }
    public string AccountId { get; set; }
    public Account Account { get; set; }
    public User User { get; set; }
}
