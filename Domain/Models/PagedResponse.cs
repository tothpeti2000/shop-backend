using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PagedResponse<T>
    {
        public List<T> Items { get; set; }
        public PageInfo PageInfo { get; set; }
    }

    public class PageInfo
    {
        public bool HasPreviousPage
        {
            get
            {
                return (CurrentPage > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (CurrentPage < TotalPages);
            }
        }

        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int Count { get; set; }
        public int TotalCount { get; set; }
    }
}
