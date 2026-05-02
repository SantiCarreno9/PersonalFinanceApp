namespace PersonalFinanceApp.Api.Features.Accounts.Common;

public sealed record AccountResponse
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string AccountType { get; init; }
    public decimal Balance { get; init; }
}
