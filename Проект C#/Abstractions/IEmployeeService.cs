using Core;

namespace Some_API.Abstractions
{
    public interface IEmployeeService
    {
        Task<Guid> CreateEmployees(Employee employee);
        Task<Guid> DeleteEmployees(Guid id);
        Task<List<Employee>> GetAllEmployees();
        Task<Guid> UpdateEmployees(Guid id, Guid merchantId, string name, string surname, string patronymic,
            string contact, string email, string password, string cardNumber);
    }
}