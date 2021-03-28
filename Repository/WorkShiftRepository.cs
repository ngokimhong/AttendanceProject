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
    class WorkShiftRepository : RepositoryBase<WorkShift>, IWorkShiftRepository
    {
        public WorkShiftRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public void CreateWorkShift(WorkShift workShift)
        {
            Create(workShift);
        }

        public void DeleteWorkShift(WorkShift workShift)
        {
            Delete(workShift);
        }

        public async Task<PagedList<WorkShift>> GetAllWorkShiftAsync(WorkShiftParameters workShiftParameters)
        {
            return await PagedList<WorkShift>.ToPageList(FindAll().OrderBy(ws => ws.ShiftId),
                workShiftParameters.PageNumber, workShiftParameters.PageSize);
        }

        public async Task<WorkShift> GetWorkShiftByIdAsync(Guid id)
        {
            return await FindByCondition(ws => ws.ShiftId == id).SingleOrDefaultAsync(); 
        }

        public async Task<PagedList<WorkShift>> GetWorkShiftByEmployeeIdAsync(WorkShiftParameters workShiftParameters)
        {
            IQueryable<WorkShift> result = FindByCondition(ws => ws.EmployeeId == workShiftParameters.EmployeeId);

            return await PagedList<WorkShift>.ToPageList(result.OrderBy(ws => ws.ShiftId),
                           workShiftParameters.PageNumber, workShiftParameters.PageSize);
        }
    

        public void UpdateWorkShift(WorkShift workShift)
        {
            Update(workShift);
        }
    }
}
