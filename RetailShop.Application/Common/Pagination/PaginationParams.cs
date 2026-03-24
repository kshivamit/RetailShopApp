using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailShop.Application.Common.Pagination
{
    public class PaginationParams
    {
        private const int MaxPageSize =50;

        public int PageNumber { get; set; } = 1;

        private int _itemPerPage = 10;

        public int ItemPerPage
        {
            get => _itemPerPage;
            set => _itemPerPage = (value > MaxPageSize) ? MaxPageSize : value;
        }
    }
}
