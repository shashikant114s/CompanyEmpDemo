using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace CompanyEmployees.Presentation.Controllers
{
    [ApiVersion("2.0", Deprecated = true)]
    [Route("api/companies")]
    [ApiController]
    public class CompaniesV2Controller : ControllerBase
    {
        private readonly IServiceManager service;

        public CompaniesV2Controller(IServiceManager service) => this.service = service;


        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await service.CompanyService.GetAllCompaniesAsync(false);
            var companies2 = companies.Select(com => $"{com.Name} V2");
            return Ok(companies2);
        }

    }
}
