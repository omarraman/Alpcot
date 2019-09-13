using System;

namespace Alpcot.Api.Dtos
{
    public class BuyOrderOut
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public string StockName { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public DateTime DatePlaced { get; set; }

    }
}