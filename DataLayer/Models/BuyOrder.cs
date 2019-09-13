using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
   public class BuyOrder
    {
        public int Id { get; set; } 
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
