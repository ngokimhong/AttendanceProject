using Entities.Models;
using Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Entities.Helper;

namespace Repository
{
    public class AttendanceRepository : RepositoryBase<Attendance>, IAttendanceRepository
    {
        public AttendanceRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public void CreateAttendance(Attendance attendance)
        {
             Create(attendance);
        }

        public void DeleteAttendance(Attendance attendance)
        {
             Delete(attendance);
        }

        public async Task<PagedList<Attendance>> GetAllAttendanceAsync(AttendanceParameters attendanceParameters )
        {
            return await PagedList<Attendance>.ToPageList(FindAll().OrderBy(att => att.AttendanceId),
                attendanceParameters.PageNumber, attendanceParameters.PageSize);
        }

        public async Task<Attendance> GetAttendanceByIdAsync(Guid id)
        {
            return await FindByCondition(att => att.AttendanceId == id ).SingleOrDefaultAsync();
        }

        public void UpdateAttendance(Attendance attendance)
        {
            Update(attendance);
        }
    }
}
