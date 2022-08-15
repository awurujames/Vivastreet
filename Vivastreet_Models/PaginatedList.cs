using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vivastreet_Models
{
    public class PaginatedList<T> : List<T> where T : class
    {
        public int PageIndex { get; set; }
        public int TotalPage { get; set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPage = (int)Math.Ceiling(count/(double)pageSize);  
            this.AddRange(items);


        }
        public bool HasPreviousPage => PageIndex > 1;   
        public bool HasNextPage => PageIndex < TotalPage;   

        public static PaginatedList<T> Create(List<T> source, int pageIndex, int pageSiz)
        {
            var count = source.Count;
            var items = source.Skip((pageIndex - 1) * pageSiz).Take(pageSiz).ToList();  
            return new PaginatedList<T>(items, count, pageIndex, pageSiz);  
        }
    }
}
