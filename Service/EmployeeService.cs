using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager repository;
        private readonly ILoggerManager logger;
        private readonly IMapper mapper;

        public EmployeeService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }


        public IEnumerable<EmployeeDto> GetEmployees(Guid companyId, bool trackChanges)
        {
            var company = repository.Company.GetCompany(companyId, trackChanges);
            if(company == null) 
                throw new CompanyNotFoundException(companyId);

            var empFromDb = repository.Employee.GetEmployees(companyId, trackChanges);
            var employeesDto = mapper.Map<IEnumerable<EmployeeDto>>(empFromDb);
            return employeesDto;
        }

        public EmployeeDto GetEmployee(Guid companyId, Guid employeeId, bool trackChanges)
        {
            var company = repository.Company.GetCompany(companyId, trackChanges);
            if( company == null )
                throw new CompanyNotFoundException(companyId);

            var employeeDb = repository.Employee.GetEmployee(companyId, employeeId, trackChanges);
            if(employeeDb == null)
                throw new EmployeeNotFoundException(employeeId);

            var employee = mapper.Map<EmployeeDto>(employeeDb);
            return employee;
        }

        public EmployeeDto CreateEmployeeForCompany(Guid companyId, EmployeeForCreationDto employeeForCreationDto, bool trackChanges)
        {
            var company = repository.Company.GetCompany(companyId, trackChanges);
            if (company == null)
                throw new CompanyNotFoundException(companyId);

            var employeeEntity = mapper.Map<Employee>(employeeForCreationDto);
            repository.Employee.CreateEmployeeForCompany(companyId, employeeEntity);
            repository.Save();

            var employeeToReturn = mapper.Map<EmployeeDto>(employeeEntity);
            return employeeToReturn;
        }

        public void DeleteEmployeeForCompany(Guid companyId, Guid id, bool trackChanges)
        {
            var company = repository.Company.GetCompany(companyId, trackChanges);
            if (company is null)
                throw new CompanyNotFoundException(companyId);

            var employeeForCompany = repository.Employee.GetEmployee(companyId, id, trackChanges);
            if(employeeForCompany is null)
                throw new EmployeeNotFoundException(id);

            repository.Employee.DeleteEmployee(employeeForCompany);
            repository.Save();
        }
    }
}
