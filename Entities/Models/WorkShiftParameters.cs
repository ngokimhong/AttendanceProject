using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class WorkShiftParameters : QueryStringParameters
    {
        public string Name { get; set; }

        public Guid EmployeeId { get; set; }
    }
}
