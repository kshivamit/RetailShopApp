using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailShop.Application.Common.Pagination
{
    public class PagedResult<T>
    {
        public int PageNumber { get; set; }
        public int ItemPerPage { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalRecords / ItemPerPage);
        public IEnumerable<T> Items { get; set; }
    }
}
