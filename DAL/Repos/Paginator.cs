using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public static class Paginator<T>
    {
        public static PagedResponse<T> Paginate(List<T> items, int page, int count)
        {
            var totalCount = items.Count;
            var chunk = items.Skip((page - 1) * count).Take(count);

            var pageInfo = new PageInfo
            {
                Count = count,
                TotalCount = totalCount,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling((double)(totalCount / count))
            };

            return new PagedResponse<T>
            {
                Items = chunk.ToList(),
                PageInfo = pageInfo
            };
        }
    }
}
