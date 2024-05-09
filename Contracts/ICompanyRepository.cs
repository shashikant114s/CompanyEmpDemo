using Entities.Models;

namespace Contracts
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetAllCompaies(bool trackChange);
        Company GetCompany(Guid companyId, bool trackChanges);

        void CreateCompany(Company company);

        IEnumerable<Company> GetByIds(IEnumerable<Guid> companyIds, bool trackChanges);

        void DeleteCompany(Company company);
    }
}
