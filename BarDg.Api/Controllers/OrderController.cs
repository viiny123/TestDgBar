using System.Threading.Tasks;
using BarDg.Domain.Commands;
using BarDg.Domain.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BarDg.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/orders")]
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
        
        [HttpPut("reset")]
        public async Task<GenericCommandResult> ResetOrder([FromBody] ResetOrderCommand command,
            [FromServices] OrderHandler handler)
        {
            return (GenericCommandResult)await handler.Handle(command);
        }
    }
}