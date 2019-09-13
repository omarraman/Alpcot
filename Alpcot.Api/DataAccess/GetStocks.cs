using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Models;

namespace Alpcot.Api.DataAccess
{
    public class GetStocks
    {
        private readonly MyDbContext _myDbContext;

        public GetStocks(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }


        public List<Dtos.StockOut> Execute()
        {
            return _myDbContext.Stocks.Select(m => new Dtos.StockOut {Id = m.Id, Name = m.Name}).ToList();
        }

    }
}
