using Entities.Helper;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IAttendanceRepository : IRepositoryBase<Attendance>
    {
        Task<PagedList<Attendance>> GetAllAttendanceAsync(AttendanceParameters attendanceParameters);

        Task<Attendance> GetAttendanceByIdAsync(Guid id);  

        void CreateAttendance(Attendance attendance);

        void UpdateAttendance(Attendance attendance);

        void DeleteAttendance(Attendance attendance);
    }
}
