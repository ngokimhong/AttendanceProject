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
        private ISortHelper<Company> _sortHelper;
        public CompanyRepository(RepositoryContext repositoryContext, ISortHelper<Company> sortHelper)
            : base(repositoryContext)
        {
            _sortHelper = sortHelper;
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
            var companies = FindAll().OrderBy(att => att.BranchId);
            SearchByName(ref companies, companyParameters.Name);
            var sortedCompany = _sortHelper.ApplySort(companies, companyParameters.OrderBy);
            return await PagedList<Company>.ToPageList(sortedCompany,
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

        public void SearchByName(ref IOrderedQueryable<Company> companies, string branchName)
        {
            if (!companies.Any() || string.IsNullOrWhiteSpace(branchName))
                return;
            companies = companies.Where(o => o.BranchName.ToLower().Contains(branchName.Trim().ToLower())).OrderBy(att => att.BranchId);
        }
    }
}
