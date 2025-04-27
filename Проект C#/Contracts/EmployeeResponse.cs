namespace Some_API.Contracts
{
    public record EmployeeResponse(
        Guid Id,
        Guid MerchantId,
        string Name,
        string Surname,
        string Patronymic,
        string Contact,
        string Email,
        string Password,
        string CardNumber);
}
