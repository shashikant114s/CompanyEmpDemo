using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.VisualBasic;
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


        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(Guid companyId, bool trackChanges)
        {
            var company = await repository.Company.GetCompanyAsync(companyId, trackChanges);
            if(company == null) 
                throw new CompanyNotFoundException(companyId);

            var empFromDb = await repository.Employee.GetEmployeesAsync(companyId, trackChanges);
            var employeesDto = mapper.Map<IEnumerable<EmployeeDto>>(empFromDb);
            return employeesDto;
        }

        public async Task<EmployeeDto> GetEmployeeAsync(Guid companyId, Guid employeeId, bool trackChanges)
        {
            var company = await repository.Company.GetCompanyAsync(companyId, trackChanges);
            if( company == null )
                throw new CompanyNotFoundException(companyId);

            var employeeDb = await repository.Employee.GetEmployeeAsync(companyId, employeeId, trackChanges);
            if(employeeDb == null)
                throw new EmployeeNotFoundException(employeeId);

            var employee = mapper.Map<EmployeeDto>(employeeDb);
            return employee;
        }

        public async Task<EmployeeDto> CreateEmployeeForCompanyAsync(Guid companyId, EmployeeForCreationDto employeeForCreationDto, bool trackChanges)
        {
            var company = await repository.Company.GetCompanyAsync(companyId, trackChanges);
            if (company == null)
                throw new CompanyNotFoundException(companyId);

            var employeeEntity = mapper.Map<Employee>(employeeForCreationDto);
            repository.Employee.CreateEmployeeForCompany(companyId, employeeEntity);
            await repository.SaveAsync();

            var employeeToReturn = mapper.Map<EmployeeDto>(employeeEntity);
            return employeeToReturn;
        }

        public async Task DeleteEmployeeForCompanyAsync(Guid companyId, Guid id, bool trackChanges)
        {
            var company = await repository.Company.GetCompanyAsync(companyId, trackChanges);
            if (company is null)
                throw new CompanyNotFoundException(companyId);

            var employeeForCompany = await repository.Employee.GetEmployeeAsync(companyId, id, trackChanges);
            if(employeeForCompany is null)
                throw new EmployeeNotFoundException(id);

            repository.Employee.DeleteEmployee(employeeForCompany);
            await repository.SaveAsync();
        }

        public async Task UpdateEmployeeForCompanyAsync(Guid companyId, Guid id, EmployeeForUpdateDto employeeForUpdate, bool companyTrackChanges, bool employeeTrackChanges)
        {
            var company = await repository.Company.GetCompanyAsync(companyId, companyTrackChanges);
            if(company is null)
                throw new CompanyNotFoundException(companyId);

            var employeeEntity = await repository.Employee.GetEmployeeAsync(companyId, id, employeeTrackChanges);
            if(employeeEntity is null)
                throw new EmployeeNotFoundException(id);

            mapper.Map(employeeForUpdate, employeeEntity);
            await repository.SaveAsync();
        }

        public async Task<(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity)> GetEmployeeForPatchAsync
            (Guid companyId, Guid id, bool compTrackChanges, bool empTrackChanges)
        {
            var company = await repository.Company.GetCompanyAsync(companyId, compTrackChanges);
            if (company is null)
                throw new CompanyNotFoundException(companyId);

            var employeeEntity = await repository.Employee.GetEmployeeAsync(companyId, id, empTrackChanges);
            if (employeeEntity is null)
                throw new EmployeeNotFoundException(companyId);

            var employeeToPatch = mapper.Map<EmployeeForUpdateDto>(employeeEntity);

            return (employeeToPatch, employeeEntity);
        }

        public async Task SaveChangesForPatchAsync(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity)
        {
            mapper.Map(employeeToPatch, employeeEntity);
            await repository.SaveAsync();
        }
    }
}
