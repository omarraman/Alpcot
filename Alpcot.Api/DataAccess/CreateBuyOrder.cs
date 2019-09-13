using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alpcot.Api.Dtos;
using Alpcot.Api.Models;
using DataLayer;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;

namespace Alpcot.Api.DataAccess
{
    public class CreateBuyOrder
    {
        private readonly MyDbContext _myDbContext;

        public CreateBuyOrder(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public BuyOrderOut Execute(BuyOrderIn buyOrderIn)
        {


            var buyOrder = new Models.BuyOrder { StockId = buyOrderIn.StockId, Price = buyOrderIn.Price,  DatePlaced = DateTime.Now };

            var compatibleSellOrders = _myDbContext.SellOrders.Where(m => m.Price <= buyOrderIn.Price && m.Quantity>0 && m.StockId==buyOrderIn.StockId)
                .OrderBy(m => m.Price).ThenBy(m => m.DatePlaced);


            foreach (var compatibleSellOrder in compatibleSellOrders)
            {
                if (buyOrderIn.Quantity>compatibleSellOrder.Quantity)
                {
                    var trade = new Trade {Price = buyOrderIn.Price, Quantity = compatibleSellOrder.Quantity, BuyOrder = buyOrder, SellOrder = compatibleSellOrder, StockId = buyOrderIn.StockId,ExecutedDate = DateTime.Now};
                    _myDbContext.Trades.Add(trade);

                    buyOrderIn.Quantity -= compatibleSellOrder.Quantity;
                    compatibleSellOrder.Quantity = 0;
                }
                else
                {
                    if (compatibleSellOrder.Quantity > buyOrderIn.Quantity)
                    {
                        var trade = new Trade { Price = buyOrderIn.Price, Quantity = buyOrderIn.Quantity, BuyOrder = buyOrder, SellOrder = compatibleSellOrder, StockId = buyOrderIn.StockId,ExecutedDate = DateTime.Now};
                        _myDbContext.Trades.Add(trade);

                        compatibleSellOrder.Quantity -= buyOrderIn.Quantity;
                        buyOrderIn.Quantity = 0;

                        break;
                    }
                    else
                    {
                        var trade = new Trade
                        {
                            Price = buyOrderIn.Price, Quantity = buyOrderIn.Quantity, BuyOrder = buyOrder,SellOrder = compatibleSellOrder,StockId = buyOrderIn.StockId,
                            ExecutedDate = DateTime.Now
                        };
                        _myDbContext.Trades.Add(trade);

                        compatibleSellOrder.Quantity = 0;
                        buyOrderIn.Quantity = 0;

                        break;
                    }
                }


            }

            buyOrder.Quantity = buyOrderIn.Quantity;
            _myDbContext.BuyOrders.Add(buyOrder);
            _myDbContext.SaveChanges();

            return new BuyOrderOut
            {
                Id = buyOrder.Id, Quantity = buyOrderIn.Quantity, Price = buyOrderIn.Price,
                DatePlaced = buyOrder.DatePlaced, StockName = "TODO", StockId = buyOrderIn.StockId
            };

        }
    }
}
