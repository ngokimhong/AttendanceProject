using Contracts;
using Entities;
using Entities.Helper;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        private ISortHelper<Employee> _sortHelper;
        public EmployeeRepository(RepositoryContext repositoryContext, ISortHelper<Employee> sortHelper)
            : base(repositoryContext)
        {
            _sortHelper = sortHelper;
        }

        public void CreateEmployee(Employee employee)
        {
            Create(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            Delete(employee);
        }

        public async Task<PagedList<Employee>> GetAllEmployeeAsync(EmployeeParameters employeeParameters)
        {
            var employees = FindAll().OrderBy(att => att.BranchId);

            SearchByName(ref employees, employeeParameters.Name);

            var sortedEmployees = _sortHelper.ApplySort(employees, employeeParameters.OrderBy);

            return await PagedList<Employee>.ToPageList(sortedEmployees,
                employeeParameters.PageNumber, employeeParameters.PageSize);
        }

        public async Task<Employee> GetEmployeeByIdAsync(Guid id)
        {
            return await FindByCondition(emp => emp.EmployeeId == id).SingleOrDefaultAsync();
        }

        public void UpdateEmployee(Employee employee)
        {
            Update(employee);
        }

        public void SearchByName(ref IOrderedQueryable<Employee> employees, string employeeName)
        {
            if (!employees.Any() || string.IsNullOrWhiteSpace(employeeName))
                return;
            employees = employees.Where(o => o.FullName.ToLower().Contains(employeeName.Trim().ToLower())).OrderBy(att => att.BranchId);
        }
    }
}
