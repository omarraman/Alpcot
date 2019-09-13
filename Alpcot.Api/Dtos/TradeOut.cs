using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alpcot.Api.Dtos
{
    public class TradeOut
    {
        public int StockId { get; set; }
        public string StockName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public DateTime ExecutedDate { get; set; }
    }
}
