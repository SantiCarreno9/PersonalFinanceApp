using PersonalFinanceApp.Api.Core.Abstractions;

namespace PersonalFinanceApp.Api.Errors;

public static class AccountErrors
{
    public static Error NotFound(int accountId) => Error.NotFound(
    "Account.NotFound",
    $"The account with the Id = '{accountId}' was not found");

    public static Error Unauthorized() => Error.Unathorized(
        "Account.Unauthorized",
        "You are not authorized to perform this action.");
    
}
