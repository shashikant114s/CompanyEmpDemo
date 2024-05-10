using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Contracts
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public async Task<IEnumerable<Company>> GetAllCompaiesAsync(bool trackChange) =>
           await FindAll(trackChange)
                .OrderBy(c => c.Name)
                .ToListAsync();

        public async Task<Company> GetCompanyAsync(Guid companyId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(companyId), trackChanges)
                .SingleOrDefaultAsync();

        public void CreateCompany(Company company) => Create(company);

        public async Task<IEnumerable<Company>> GetByIdsAsync(IEnumerable<Guid> companyIds, bool trackChanges) => 
           await FindByCondition(x => companyIds.Contains(x.Id), trackChanges)
                .ToListAsync();

        public void DeleteCompany(Company company) => Delete(company);
    }
}
