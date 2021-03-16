using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
     public interface IRepositoryWrapper
    {
        IAttendanceRepository Attendance { get; }
        IEmployeeRepository Employee { get; }
        ICompanyRepository Company { get; }
        IWorkShiftRepository WorkShift { get; }

        Task save();
    }
}
