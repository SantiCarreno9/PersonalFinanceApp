using PersonalFinanceApp.Api.Core.Abstractions;

namespace PersonalFinanceApp.Api.Errors;

public static class TransferErrors
{
    public static Error NotFound(int transferId) => Error.NotFound(
    "Transfer.NotFound",
    $"The transfer with the Id = '{transferId}' was not found");

    public static Error Unauthorized() => Error.Unathorized(
        "Transfer.Unauthorized",
        "You are not authorized to perform this action.");
}
