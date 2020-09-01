using System.Collections.Generic;
using System.Threading.Tasks;
using BarDg.Domain.Entities;
using BarDg.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BarDg.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/item")]
    public class ItemController : ControllerBase
    {
        [HttpGet]
        public async Task<List<Item>> GetItems([FromServices] IItemRepository itemRepository)
        {
            return await itemRepository.GetAll();
        }
    }
}