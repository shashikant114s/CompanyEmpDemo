using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace CompanyEmployees.Presentation.Controllers
{
    [ApiController]
    [Route("api/companies/{companyId}/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly IServiceManager service;

        public EmployeesController(IServiceManager service) => this.service = service;

        [HttpGet]
        public IActionResult GetEmployeesForCompany(Guid companyId)
        {
            var employees = service.EmployeeService.GetEmployees(companyId, false);
            return Ok(employees);
        }

        [HttpGet("{empId:guid}")]
        public IActionResult GetEmployeeForCompany(Guid companyId, Guid empId)
        {
            var employee = service.EmployeeService.GetEmployee(companyId, empId, false);
            return Ok(employee);
        }
    }
}
