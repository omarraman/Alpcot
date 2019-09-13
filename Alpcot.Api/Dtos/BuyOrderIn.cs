namespace Alpcot.Api.Dtos
{
    public class BuyOrderIn
    {
        public int StockId { get; set; }
        public double Price { get; set; }

        public int Quantity { get; set; }
    }


    public class BuyOrderIn2
    {
        public string stockId { get; set; }

    }
}