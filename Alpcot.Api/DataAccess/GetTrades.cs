using System.Collections.Generic;
using System.Linq;
using DataLayer;

namespace Alpcot.Api.DataAccess
{
    public class GetTrades
    {
        private readonly MyDbContext _myDbContext;

        public GetTrades(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }


        public List<Dtos.TradeOut> Execute()
        {
            return _myDbContext.Trades.Select(m => new Dtos.TradeOut() {StockId = m.Id, StockName = m.Stock.Name,Quantity = m.Quantity,Price = m.Price,ExecutedDate = m.ExecutedDate}).ToList();
        }

    }
}
