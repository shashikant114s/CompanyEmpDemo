using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

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

        [HttpGet("{empId:guid}", Name = "GetEmployeeForCompany")]
        public IActionResult GetEmployeeForCompany(Guid companyId, Guid empId)
        {
            var employee = service.EmployeeService.GetEmployee(companyId, empId, false);
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult CreateEmployeeForCompany(Guid companyId, [FromBody] EmployeeForCreationDto employeeForCreationDto)
        {
            if (employeeForCreationDto == null)
                return BadRequest("EmployeeForCreationDto object is null.");

            var employeeToReturn = service.EmployeeService.CreateEmployeeForCompany(companyId, employeeForCreationDto, false);
            return CreatedAtRoute("GetEmployeeForCompany", new
            {
                companyId,
                empId = employeeToReturn.Id
            }, employeeToReturn);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteEmployeeForCompany(Guid companyId, Guid id)
        {
            service.EmployeeService.DeleteEmployeeForCompany(companyId, id, false);
            return NoContent();
        }
    }
}
