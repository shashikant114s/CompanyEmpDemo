using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {

        private readonly Lazy<ICompanyService> companyService;
        private readonly Lazy<IEmployeeService> employeeService;


        public ServiceManager(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            companyService = new Lazy<ICompanyService>(() => new CompanyService(repository, logger, mapper));
            employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(repository, logger, mapper));
        }

        public ICompanyService CompanyService => companyService.Value;

        public IEmployeeService EmployeeService => employeeService.Value;
    }
}
