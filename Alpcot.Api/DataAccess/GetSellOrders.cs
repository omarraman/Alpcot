using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;

namespace Alpcot.Api.DataAccess
{
    public class GetSellOrders
    {
        private readonly MyDbContext _myDbContext;

        public GetSellOrders(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }


        public List<Dtos.SellOrderOut> Execute()
        {
            return _myDbContext.SellOrders.Select(m => new Dtos.SellOrderOut()
            {
                StockId = m.StockId,
                StockName = m.Stock.Name,
                Quantity = m.Quantity,
                Price = m.Price,
                DatePlaced = m.DatePlaced
            }).ToList();
        }

    }
}
