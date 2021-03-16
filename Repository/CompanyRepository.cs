using Contracts;
using Entities;
using Entities.Helper;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public void CreateCompany(Company company)
        {
            Create(company);
        }

        public void DeleteCompany(Company company)
        {
            Delete(company);
        }

        public async Task<PagedList<Company>> GetAllCompanyAsync(CompanyParameters companyParameters)
        {
            //return await FindAll().OrderBy(com => com.BranchId).ToListAsync();
            return await PagedList<Company>.ToPageList(FindAll().OrderBy(att => att.BranchId),
                companyParameters.PageNumber, companyParameters.PageSize);
        }

        public async Task<Company> GetCompanyByIdAsync(Guid id)
        {
            return await FindByCondition(com => com.BranchId == id).SingleOrDefaultAsync();
        }

        public void UpdateCompany(Company company)
        {
            Update(company);
        }
    }
}
