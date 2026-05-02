namespace PersonalFinanceApp.Api.Features.Users.Common;

public sealed record UserResponse
{
    public string Id { get; init; }
    public string Email { get; init; }
    public string FullName { get; init; }
}
