namespace PersonalFinanceApp.Api.Entities;

public class User
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string FullName { get; set; }
    public string PasswordHash { get; set; }

    public List<Account> Accounts { get; set; } = [];
}
