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
    public class CreateSellOrderController : ControllerBase
    {

        private MyDbContext _dbContext;

        public CreateSellOrderController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public ActionResult<SellOrderOut> PostSellOrder([FromBody] SellOrderIn sellOrder)
        {
            return new CreateSellOrder(_dbContext).Execute(sellOrder);
        }
    }
}
