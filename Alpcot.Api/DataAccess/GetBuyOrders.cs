using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;

namespace Alpcot.Api.DataAccess
{
    public class GetBuyOrders
    {
        private readonly MyDbContext _myDbContext;

        public GetBuyOrders(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }


        public List<Dtos.BuyOrderOut> Execute()
        {
            return _myDbContext.BuyOrders.Select(m => new Dtos.BuyOrderOut() {StockId = m.StockId,StockName = m.Stock.Name,
                Quantity = m.Quantity,Price = m.Price,DatePlaced = m.DatePlaced}).ToList();
        }

    }
}
