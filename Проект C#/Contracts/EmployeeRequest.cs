namespace Some_API.Contracts
{
    public record EmployeeRequest(
        Guid MerchantId,
        string Name,
        string Surname ,
        string Patronymic ,
        string Contact ,
        string Email ,
        string Password ,
        string CardNumber);
}
