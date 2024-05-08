﻿using Entities.Models;

namespace Contracts
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetAllCompaies(bool trackChange);
        Company GetCompany(Guid companyId, bool trackChanges);

        void CreateCompany(Company company);
    }
}
