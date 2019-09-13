using System;
using DataLayer.Models;

namespace Alpcot.Api.Models
{
    public class BuyOrder
    {
        public int Id { get; set; }

        public double Price { get; set; }
        public int Quantity { get; set; }

        public int StockId { get; set; }

        public DateTime DatePlaced { get; set; }

        public Stock Stock { get; set; }

    }
}
