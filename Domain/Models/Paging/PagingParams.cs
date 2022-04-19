using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Paging
{
    public class PagingParams
    {
        // Default values
        private int page = 1;
        private int limit = 20;

        private readonly int minPage = 1;
        private readonly int minLimit = 0;
        private readonly int maxLimit = 50;

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

        public int Limit
        {
            get
            {
                return limit;
            }

            set
            {
                if (value < minLimit)
                {
                    limit = minLimit;
                } else if (value > maxLimit)
                {
                    limit = maxLimit;
                } else
                {
                    limit = value;
                }
            }
        }
    }
}
