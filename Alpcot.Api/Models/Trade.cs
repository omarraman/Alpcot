using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Alpcot.Api.Models
{
    public class Trade
    {
        public int Id { get; set; }

        public int Quantity { get; set; }
        public double Price { get; set; }
        public int StockId { get; set; }

        public DateTime ExecutedDate { get; set; }

        public  BuyOrder BuyOrder{ get; set; }
        public  SellOrder SellOrder{ get; set; }
        public Stock Stock { get; set; }

    }
}
