using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vivastreet_Models
{
    public class Pager
    {
        public int TotalItems { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }

        public Pager()
        {

        }

        public Pager(int totalItems, int page, int pageSige = 10)
        {
            int totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSige);
            int currentPage = page;

            int startPage = CurrentPage - 5;
            int endPage = CurrentPage + 4;

            if (startPage <= 0)
            {
                endPage = endPage - (startPage - 1);
                startPage = 1;
            }

            if (endPage > TotalPages)
            {
                endPage = totalPages;
                if (endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }

            TotalPages = totalPages;
            CurrentPage = currentPage;
            PageSize = pageSige;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;


        }


    }
}
