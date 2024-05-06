using Entities.Models;

namespace Contracts
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetAllCompaies(bool trackChange);
    }
}
