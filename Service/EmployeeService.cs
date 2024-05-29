using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System.Dynamic;

namespace Service
{
    internal sealed class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager repository;
        private readonly ILoggerManager logger;
        private readonly IMapper mapper;
        private readonly IDataShaper<EmployeeDto> dataShaper;

        public EmployeeService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, IDataShaper<EmployeeDto> dataShaper)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
            this.dataShaper=dataShaper;
        }


        public async Task<(IEnumerable<ExpandoObject> employees, MetaData metaData)> GetEmployeesAsync(Guid companyId, EmployeeParamerters employeeParamerters, bool trackChanges)
        {
            if (!employeeParamerters.ValidAgeRange)
                throw new MaxAgeRangeBadrequestException();

            await GetCompanyIfExist(companyId, trackChanges);

            var employeeWithMetaData = await repository.Employee.GetEmployeesAsync(companyId, employeeParamerters, trackChanges);
            //var empFromDb = await repository.Employee.GetEmployeesAsync(companyId, employeeParamerters, trackChanges);
            var employeesDto = mapper.Map<IEnumerable<EmployeeDto>>(employeeWithMetaData);
            var shapedData = dataShaper.ShapeData(employeesDto, employeeParamerters.Fields);
            return (shapedData, employeeWithMetaData.MetaData);
        }

        public async Task<EmployeeDto> GetEmployeeAsync(Guid companyId, Guid employeeId, bool trackChanges)
        {
            await GetCompanyIfExist(companyId, trackChanges);

            var employeeDb = await GetEmployeeIfExist(companyId, employeeId, trackChanges);

            var employee = mapper.Map<EmployeeDto>(employeeDb);
            return employee;
        }

        public async Task<EmployeeDto> CreateEmployeeForCompanyAsync(Guid companyId, EmployeeForCreationDto employeeForCreationDto, bool trackChanges)
        {
            await GetCompanyIfExist(companyId, trackChanges);

            var employeeEntity = mapper.Map<Employee>(employeeForCreationDto);
            repository.Employee.CreateEmployeeForCompany(companyId, employeeEntity);
            await repository.SaveAsync();

            var employeeToReturn = mapper.Map<EmployeeDto>(employeeEntity);
            return employeeToReturn;
        }

        public async Task DeleteEmployeeForCompanyAsync(Guid companyId, Guid id, bool trackChanges)
        {
            await GetCompanyIfExist(companyId, trackChanges);

            var employee = await GetEmployeeIfExist(companyId, id, trackChanges);

            repository.Employee.DeleteEmployee(employee);
            await repository.SaveAsync();
        }

        public async Task UpdateEmployeeForCompanyAsync(Guid companyId, Guid id, EmployeeForUpdateDto employeeForUpdate, bool companyTrackChanges, bool employeeTrackChanges)
        {
            await GetCompanyIfExist(companyId, companyTrackChanges);

            var employeeDb = await GetEmployeeIfExist(companyId, id, employeeTrackChanges);

            mapper.Map(employeeForUpdate, employeeDb);
            await repository.SaveAsync();
        }

        public async Task<(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity)> GetEmployeeForPatchAsync
            (Guid companyId, Guid id, bool compTrackChanges, bool empTrackChanges)
        {
            await GetCompanyIfExist(companyId, compTrackChanges);

            var employeeDb = await GetEmployeeIfExist(companyId, id, empTrackChanges);

            var employeeToPatch = mapper.Map<EmployeeForUpdateDto>(employeeDb);

            return (employeeToPatch, employeeDb);
        }

        public async Task SaveChangesForPatchAsync(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity)
        {
            mapper.Map(employeeToPatch, employeeEntity);
            await repository.SaveAsync();
        }

        private async Task GetCompanyIfExist(Guid companyId, bool trackChanges)
        {
            var company = await repository.Company.GetCompanyAsync(companyId, trackChanges);

            if (company is null)
                throw new CompanyNotFoundException(companyId);
        }

        private async Task<Employee> GetEmployeeIfExist(Guid companyId, Guid employeeId, bool trackChanges)
        {
            var employee = await repository.Employee.GetEmployeeAsync(companyId, employeeId, trackChanges);
            if (employee == null)
                throw new EmployeeNotFoundException(employeeId);

            return employee;
        }
    }
}
