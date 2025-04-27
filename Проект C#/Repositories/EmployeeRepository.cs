using Core;
using Microsoft.EntityFrameworkCore;
using Some_API.Abstractions;
using Some_API.Data;
using Some_API.Data.Entities;
using System.Xml.Linq;

namespace Some_API.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext context;
        public EmployeeRepository(EmployeeDbContext _context)
        {
            context = _context;
        }

        public async Task<List<Employee>> Get()
        {
            var employeeEntities = await context.Employees
                .AsNoTracking()
                .ToListAsync();

            var employees = employeeEntities
                .Select(m => Employee.Create(m.Id, m.MerchantId, m.Name, m.Surname, m.Patronymic, m.Contact,
                m.Email, m.Password, m.CardNumber).employee)
                .ToList();

            return employees;
        }

        public async Task<Guid> Create(Employee employee)
        {
            var employeeEntity = new EmployeeEntity
            {
                Id = employee.Id,
                MerchantId = employee.MerchantId,
                Name = employee.Name,
                Surname = employee.Surname,
                Patronymic = employee.Patronymic,
                Contact = employee.Contact,
                Email = employee.Email,
                Password = employee.Password,
                CardNumber = employee.CardNumber,
            };
            await context.Employees.AddAsync(employeeEntity);
            await context.SaveChangesAsync();

            return employeeEntity.Id;
        }

        public async Task<Guid> Update(Guid id, Guid merchantId, string name, string surname, string patronymic,
            string contact, string email, string password, string cardNumber)
        {
            await context.Employees
                .Where(m => m.Id == id)
                .ExecuteUpdateAsync(x => x
                .SetProperty(a => a.Name, name)
                .SetProperty(a => a.Surname, surname)
                .SetProperty(a => a.Patronymic, patronymic)
                .SetProperty(a => a.Contact, contact)
                .SetProperty(a => a.Email, email)
                .SetProperty(a => a.CardNumber, cardNumber));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await context.Employees
                .Where(m => m.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
