using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.QueryParams.Paging
{
    public class PagingParams
    {
        // Default values
        private int page = 1;
        private int count = 20;

        private readonly int minPage = 1;
        private readonly int minCount = 0;
        private readonly int maxCount = 50;

        public int Page
        {
            get => page;
            set => page = value < minPage ? minPage : value;
        }

        public int Count
        {
            get => count;
            set => count = value < minCount ? minCount : value > maxCount ? maxCount : value;
        }
    }
}
