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
    public class CreateBuyOrderController : ControllerBase
    {

        private MyDbContext _dbContext;

        public CreateBuyOrderController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public ActionResult<BuyOrderOut> PostBuyOrder([FromBody] BuyOrderIn buyOrder)
        {
            return new CreateBuyOrder(_dbContext).Execute(buyOrder);
        }

    }
}
