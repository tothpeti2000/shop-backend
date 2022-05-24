using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.QueryParams.SortFilter
{
    public class SortFilterParams
    {
        // Default values
        private string sort = "all";
        private string filter = "all";

        private string[] sortOptions = new string[] { "nameAZ", "nameZA", "priceLTH", "priceHTL" };

        public string Sort
        {
            get => sort; 

            set
            {
                foreach (var sortOption in sortOptions)
                {
                    if (value == sortOption)
                    {
                        sort = value;
                        return;
                    }
                }

                sort = "all";
            }
        }

        public string Filter { 
            get => filter;

            set
            {
                filter = "all";
            }
        }
    }
}
