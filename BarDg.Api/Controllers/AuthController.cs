using System.Threading.Tasks;
using BarDg.Api.Authorizations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BarDg.Api.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/account")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthUser _authUser;
        public AuthController(IAuthUser authUser)
        {
            _authUser = authUser;
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginUser)
        {
            var result = await _authUser.LoginAsync(loginUser);
            return Ok(result);
        }
    }
}