using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class CompanyParameters : QueryStringParameters
    {
        public CompanyParameters()
        {
            OrderBy = "BranchName";
        }

        public string Name { get; set; }

    }
}
