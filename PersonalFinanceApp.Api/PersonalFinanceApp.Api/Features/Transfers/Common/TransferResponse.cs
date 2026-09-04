namespace PersonalFinanceApp.Api.Features.Transfers.Common;

public sealed record TransferResponse {
    public long Id { get; init; }
    public int OriginAccountId { get; init; }
    public int DestinationAccountId { get; init; }
    public decimal Amount { get; init; }
    public string? Description { get; init; }
};
