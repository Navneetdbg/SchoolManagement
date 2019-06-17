using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.web.ViewModel
{
    public class BaseListingViewModel
    {
    }

    public class Pager
    {
        public Pager(int totalItems, int? Page, int pageSize = 10)
        {
            if (pageSize == 0) pageSize = 10;
            var totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
            var currentPage = Page != null ? (int)Page : 1;
            var startPage = currentPage - 5;
            var endPage = currentPage + 4;
            if (startPage <= 0)
            {
                endPage -= (startPage - 1);
                startPage = 1;
            }
            if (endPage > totalPages)
            {
                endPage = totalPages;
                if (endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }
            TotalItems = totalItems;
            CurrenPage = currentPage;
            PageSize = pageSize;
            TotalPage = totalPages;
            StartPage = startPage;
            EndPage = endPage;
        }
        public int TotalItems { get; private set; }
        public int CurrenPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPage { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }
    }
}