using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alpcot.Api.Dtos;
using Alpcot.Api.Models;
using DataLayer;

namespace Alpcot.Api.DataAccess
{
    public class CreateSellOrder
    {
        private readonly MyDbContext _myDbContext;

        public CreateSellOrder(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public SellOrderOut Execute(Dtos.SellOrderIn sellOrderIn)
        {

            var sellOrder = new Models.SellOrder { StockId = sellOrderIn.StockId, Price = sellOrderIn.Price,  DatePlaced = DateTime.Now };


            var compatibleBuyOrders = _myDbContext.BuyOrders.Where(m => m.Price >= sellOrderIn.Price && m.Quantity>0 && m.StockId==sellOrderIn.StockId)
                .OrderByDescending(m => m.Price).ThenBy(m => m.DatePlaced);



            foreach (var compatibleBuyOrder in compatibleBuyOrders)
            {
                if (sellOrderIn.Quantity > compatibleBuyOrder.Quantity)
                {


                    var trade = new Trade { Price = compatibleBuyOrder.Price, Quantity = compatibleBuyOrder.Quantity, BuyOrder = compatibleBuyOrder, SellOrder = sellOrder,StockId = sellOrderIn.StockId,ExecutedDate = DateTime.Now}; ;
                    _myDbContext.Trades.Add(trade);

                    sellOrderIn.Quantity -= compatibleBuyOrder.Quantity;
                    compatibleBuyOrder.Quantity = 0;
                }
                else
                {
                    if (compatibleBuyOrder.Quantity > sellOrderIn.Quantity)
                    {

                        var trade = new Trade { Price = compatibleBuyOrder.Price, Quantity = sellOrderIn.Quantity, BuyOrder = compatibleBuyOrder, SellOrder = sellOrder, StockId = sellOrderIn.StockId,ExecutedDate = DateTime.Now}; ;
                        _myDbContext.Trades.Add(trade);

                        compatibleBuyOrder.Quantity -= sellOrderIn.Quantity;
                        sellOrderIn.Quantity = 0;


                        break;
                    }
                    else
                    {
                        var trade = new Trade { Price = compatibleBuyOrder.Price, Quantity = sellOrderIn.Quantity, BuyOrder = compatibleBuyOrder, SellOrder = sellOrder, StockId = sellOrderIn.StockId ,ExecutedDate = DateTime.Now}; ;
                        _myDbContext.Trades.Add(trade);

                        compatibleBuyOrder.Quantity = 0;
                        sellOrderIn.Quantity = 0;

                        break;
                    }
                }


            }

            sellOrder.Quantity = sellOrderIn.Quantity;
            _myDbContext.SellOrders.Add(sellOrder);
            _myDbContext.SaveChanges();

            return new SellOrderOut
            {
                Id = sellOrder.Id,
                StockId = sellOrderIn.StockId, Quantity = sellOrderIn.Quantity, Price = sellOrderIn.Price,DatePlaced = sellOrder.DatePlaced,
                StockName = "TODO"
            };


        }
    }
}
