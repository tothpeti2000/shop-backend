﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Cart
    {
        public int ID { get; set; }
        public User User { get; set; }
        public bool Active { get; set; } = true;
        public List<CartItem> Items { get; set; }
    }
}
