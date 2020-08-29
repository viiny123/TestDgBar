using System.Collections.Generic;
using System.Threading.Tasks;
using BarDg.Domain.Commands;
using BarDg.Domain.Entities;
using BarDg.Domain.Handlers;
using BarDg.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BarDg.Api.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrderController: ControllerBase
    {
        [HttpPost]
        public GenericCommandResult Create([FromBody] CreateOrderCommand command, 
            [FromServices] OrderHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }
        
        [HttpGet]
        public async Task<List<Order>> GetAll(string code, 
            [FromServices] IOrderRepository repository)
        {
            return await repository.GetAll(code);
        }
    }
}