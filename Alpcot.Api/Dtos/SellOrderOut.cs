using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alpcot.Api.Dtos
{
    public class SellOrderOut
    {
        public int Id { get; set; }

        public int StockId { get; set; }
        public string StockName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public DateTime DatePlaced { get; set; }

    }
}
