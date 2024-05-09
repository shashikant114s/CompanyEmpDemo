using Entities.Models;
using Repository;

namespace Contracts
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public IEnumerable<Company> GetAllCompaies(bool trackChange) =>
            FindAll(trackChange)
                .OrderBy(c => c.Name)
                .ToList();

        public Company GetCompany(Guid companyId, bool trackChanges) =>
            FindByCondition(c => c.Id.Equals(companyId), trackChanges)
                .SingleOrDefault();

        public void CreateCompany(Company company) => Create(company);

        public IEnumerable<Company> GetByIds(IEnumerable<Guid> companyIds, bool trackChanges) => 
            FindByCondition(x => companyIds.Contains(x.Id), trackChanges)
                .ToList();

        public void DeleteCompany(Company company) => Delete(company);
    }
}
