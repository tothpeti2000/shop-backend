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
        private float fromPrice = 0;
        private float toPrice = 0;

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

        public float FromPrice
        {
            get => fromPrice;
            set => fromPrice = value < 0 ? 0 : value > toPrice ? toPrice : value;
        }

        public float ToPrice { 
            get => toPrice;
            set => toPrice = value < fromPrice ? fromPrice : value;
        }
    }
}
