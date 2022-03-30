using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PagingParams
    {
        private int page = 1;
        private int count = 10;

        private readonly int minPage = 1;
        private readonly int maxPageCount = 50;

        public int Page
        {
            get
            {
                return page;
            }

            set
            {
                if (value < minPage)
                {
                    page = minPage;
                    
                }
                else
                {
                    page = value;
                }
            }
        }

        public int Count
        {
            get
            {
                return count;
            }

            set
            {
                if (value > maxPageCount)
                {
                    count = maxPageCount;
                }
                else
                {
                    count = value;
                }
            }
        }
    }
}
