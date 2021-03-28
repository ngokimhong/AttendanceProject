using Entities.Helper;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IWorkShiftRepository : IRepositoryBase<WorkShift>
    {
        Task<PagedList<WorkShift>> GetAllWorkShiftAsync(WorkShiftParameters workShiftParameters);
        Task<PagedList<WorkShift>> GetWorkShiftByEmployeeIdAsync(WorkShiftParameters workShiftParameters);
        Task<WorkShift> GetWorkShiftByIdAsync(Guid id);
        void CreateWorkShift(WorkShift workShift);
        void UpdateWorkShift(WorkShift workShift);
        void DeleteWorkShift(WorkShift workShift);
    }
}
