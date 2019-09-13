using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class SellOrder
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
