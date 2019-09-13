using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alpcot.Api.Dtos
{
    public class SellOrderIn
    {
        public int StockId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

    }
}
