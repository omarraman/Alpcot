using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alpcot.Api.DataAccess;
using Alpcot.Api.Dtos;
using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace Alpcot.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradesController : ControllerBase
    {

        private MyDbContext _dbContext;

        public TradesController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<List<TradeOut>> Get()
        {
            return new GetTrades(_dbContext).Execute();
        }

       
    }
}
