using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private ICompanyRepository _company;
        private IEmployeeRepository _employee;
        private IAttendanceRepository _attendance;
        private IWorkShiftRepository _workShift;

        public ICompanyRepository Company
        {
            get
            {
                if(_company == null)
                {
                    _company = new CompanyRepository(_repoContext);
                }
                return _company;
            }
        }

        public IEmployeeRepository Employee
        {
            get
            {
                if(_employee == null)
                {
                    _employee = new EmployeeRepository(_repoContext);
                }
                return _employee;
            }
        }

        public IAttendanceRepository Attendance
        {
            get
            {
                if(_attendance == null)
                {
                    _attendance = new AttendanceRepository(_repoContext);
                }
                return _attendance;
            }
        }

        public IWorkShiftRepository WorkShift
        {
            get
            {
                if(_workShift == null)
                {
                    _workShift = new WorkShiftRepository(_repoContext);
                }
                return _workShift;
            }
        }
        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public async Task save()
        {
            await _repoContext.SaveChangesAsync();
        }

    }
}
