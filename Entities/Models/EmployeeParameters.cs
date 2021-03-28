using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class EmployeeParameters : QueryStringParameters
    {
        public EmployeeParameters()
        {
            OrderBy = "Fullname";
        }

        public string Name { get; set; }
    }
}
