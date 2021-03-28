using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public abstract class QueryStringParameters
    {
        const int maxPageSize = 1000;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 30;
        public int PageSize {
            get {
                return _pageSize;
            }
            set {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
        public string OrderBy { get; set; }
    }
}
