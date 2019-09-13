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
    public class GetBuyOrdersController : ControllerBase
    {

        private MyDbContext _dbContext;

        public GetBuyOrdersController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<List<BuyOrderOut>> Get()
        {
            return new GetBuyOrders(_dbContext).Execute();
        }

       
    }
}
