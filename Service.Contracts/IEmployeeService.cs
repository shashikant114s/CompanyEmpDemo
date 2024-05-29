﻿using Entities.Models;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System.Dynamic;

namespace Service.Contracts
{
    public interface IEmployeeService
    {
        Task<(IEnumerable<ExpandoObject> employees, MetaData metaData)> GetEmployeesAsync(Guid companyId, EmployeeParamerters employeeParamerters, bool trackChanges);

        Task<EmployeeDto> GetEmployeeAsync(Guid companyId,  Guid employeeId, bool trackChanges);

        Task<EmployeeDto> CreateEmployeeForCompanyAsync(Guid companyId, EmployeeForCreationDto employeeForCreationDto, bool trackChanges);

        Task DeleteEmployeeForCompanyAsync(Guid companyId, Guid id, bool trackChanges);

        Task UpdateEmployeeForCompanyAsync(Guid companyId, Guid id, EmployeeForUpdateDto employeeForUpdate, bool companyTrackChanges, bool employeeTrackChanges);

        Task<(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity)> GetEmployeeForPatchAsync(
     Guid companyId, Guid id, bool compTrackChanges, bool empTrackChanges);
        Task SaveChangesForPatchAsync(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity);
    }
}
