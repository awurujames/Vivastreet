using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vivastreet_Models
{
    public class Pager : BaseDomain
    {
        public int TotalItems { get; private set; } //Gives total number of records*****
        public int CurrentPage { get; private set; } // gives the active page of the pager bar
        public int PageSize { get; private set; } // gives the number of recoed to be displayed in a page****
        public int TotalPages { get; private set; } // Gives the total number of pages in the pager bar
        public int StartPage { get; private set; } // Gives the (current) start page in the pager bar
        public int EndPage { get; private set; } // Gives the (current) end page in the pager bar

        public Pager()
        {

        }

        public Pager(int totalItems, int page, int pageSize = 4)
        {
            int totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
            int currentPage = page;

            int startPage = CurrentPage - 1;
            int endPage = CurrentPage + 1;

            if (startPage <= 0)
            {
                endPage = endPage - (startPage - 1);
                startPage = 1;
            }

            if (endPage > TotalPages)
            {
                endPage = totalPages;
                if (endPage > 4)
                {
                    startPage = endPage - 3;
                }
            }

            TotalPages = totalPages;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;


        }


    }
}
