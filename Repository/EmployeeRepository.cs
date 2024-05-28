using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }


        public async Task<PagedList<Employee>> GetEmployeesAsync(Guid companyId, EmployeeParamerters employeeParamerters, bool trackChanges)
        {
            var employees = await FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
                  .FilterEmployee(employeeParamerters.MinAge, employeeParamerters.MaxAge)
                  .Search(employeeParamerters.SearchTerm)
                  .OrderBy(e => e.Name)
                  .Skip((employeeParamerters.PageNumber - 1) * employeeParamerters.PageSize)
                  .Take(employeeParamerters.PageSize)
                  .ToListAsync();

            var count = await FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges).CountAsync();

            return new PagedList<Employee>(employees, count, employeeParamerters.PageNumber, employeeParamerters.PageSize);
        }

        public async Task<Employee> GetEmployeeAsync(Guid companyId, Guid employeeId, bool trackChanges) =>
           await FindByCondition(e => e.CompanyId.Equals(companyId) && e.Id.Equals(employeeId), trackChanges)
                .SingleOrDefaultAsync();

        public void CreateEmployeeForCompany(Guid companyId, Employee employee)
        {
            employee.CompanyId = companyId;
            Create(employee);
        }

        public void DeleteEmployee(Employee employee) => Delete(employee);
    }
}
