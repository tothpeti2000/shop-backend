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
        private string sort = "none";
        private string filter = "none";

        private string[] sortOptions = new string[] { "nameAsc", "nameDesc", "priceAsc", "priceDesc" };

        public string Sort
        {
            get 
            { 
                return sort; 
            }

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

                sort = "none";
            }
        }

        public string Filter { 
            get
            {
                return filter;
            }

            set
            {
                filter = "none";
            }
        }
    }
}
