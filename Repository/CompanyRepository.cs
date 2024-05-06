using Entities.Models;
using Repository;

namespace Contracts
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Company> GetAllCompaies(bool trackChange) =>
            FindAll(trackChange)
                .OrderBy(c => c.Name)
                .ToList();
    }
}
