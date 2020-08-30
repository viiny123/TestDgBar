using System.Collections.Generic;
using System.Threading.Tasks;
using BarDg.Domain.Commands;
using BarDg.Domain.Entities;
using BarDg.Domain.Handlers;
using BarDg.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BarDg.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("orders")]
    public class OrderController: ControllerBase
    {
        [HttpPost("create")]
        public async Task<GenericCommandResult> Create([FromBody] CreateOrderCommand command, 
            [FromServices] OrderHandler handler)
        {
            return (GenericCommandResult)await handler.Handle(command);
        }

        [HttpPut("close")]
        public async Task<GenericCommandResult> CloseOrder([FromBody] CloseOrderCommand command,
            [FromServices] OrderHandler handler)
        {
            return (GenericCommandResult)await handler.Handle(command);
        }
        
        [HttpGet]
        public async Task<List<Order>> GetAll(string code, 
            [FromServices] IOrderRepository repository)
        {
            return await repository.GetAll(code);
        }
    }
}