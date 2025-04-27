using Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Some_API.Abstractions;
using Some_API.Contracts;
using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Some_API.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeResponse>>> GetEmployees()
        {
            var employees = await _employeeService.GetAllEmployees();

            var response = employees.Select(response => new EmployeeResponse(
                response.Id,
                response.MerchantId,
                response.Name,
                response.Surname,
                response.Patronymic,
                response.Contact,
                response.Email,
                response.Password,
                response.CardNumber));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateEmployees([FromBody] EmployeeRequest request)
        {
            var (employee, error) = Employee.Create(
                Guid.NewGuid(),
                request.MerchantId,
                request.Name,
                request.Surname,
                request.Patronymic,
                request.Contact,
                request.Email,
                request.Password,
                request.CardNumber);
            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var employeeId = await _employeeService.CreateEmployees(employee);

            return Ok(employeeId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateEmployees([FromBody] EmployeeRequest request, Guid id)
        {
            var employeeId = await _employeeService.UpdateEmployees(id, request.MerchantId,
                request.Name,
                request.Surname,
                request.Patronymic,
                request.Contact,
                request.Email,
                request.Password,
                request.CardNumber);
            return Ok(employeeId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteEmployees(Guid id)
        {
            var employeeId = await _employeeService.DeleteEmployees(id);
            return Ok(employeeId);
        }
    }
}
