using Core;

namespace Some_API.Abstractions
{
    public interface IEmployeeRepository
    {
        Task<Guid> Create(Employee employee);
        Task<Guid> Delete(Guid id);
        Task<List<Employee>> Get();
        Task<Guid> Update(Guid id, Guid merchantId, string name, string surname, string patronymic,
            string contact, string email, string password, string cardNumber);
    }
}