namespace Some_API.Contracts
{
    public record MerchantResponse(
        Guid id,
        string title,
        string status,
        string description);
}
