using Core;
using Some_API.Abstractions;

namespace Some_API.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _employeeRepository.Get();
        }

        public async Task<Guid> CreateEmployees(Employee employee)
        {
            return await _employeeRepository.Create(employee);
        }

        public async Task<Guid> UpdateEmployees(Guid id, Guid merchantId, string name, string surname, string patronymic,
            string contact, string email, string password, string cardNumber)
        {
            return await _employeeRepository.Update(id, merchantId, name, surname, patronymic,
            contact, email, password, cardNumber);
        }

        public async Task<Guid> DeleteEmployees(Guid id)
        {
            return await _employeeRepository.Delete(id);
        }
    }
}
