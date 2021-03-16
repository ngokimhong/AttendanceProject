using Entities.Helper;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICompanyRepository : IRepositoryBase<Company>
    {
        Task<PagedList<Company>> GetAllCompanyAsync(CompanyParameters companyParameters);

        Task<Company> GetCompanyByIdAsync(Guid id);

        void CreateCompany(Company company);

        void UpdateCompany(Company company);

        void DeleteCompany(Company company);
    }
}
