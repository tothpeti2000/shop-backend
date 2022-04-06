﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PagedResponse<T>
    {
        public List<T> Items { get; set; }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }

        public Uri nextPage { get; set; }
        public Uri previousPage { get; set; }
    }
}
