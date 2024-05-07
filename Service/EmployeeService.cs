﻿using AutoMapper;
using Contracts;
using Entities.Exceptions;
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
    }
}
