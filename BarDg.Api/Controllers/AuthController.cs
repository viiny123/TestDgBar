using System.Threading.Tasks;
using BarDg.Api.Authorizations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NetDevPack.Identity.Jwt;

namespace BarDg.Api.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthUser _authUser;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly AppJwtSettings _appJwtSettings;

        public AuthController(IAuthUser authUser, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IOptions<AppJwtSettings> appJwtSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appJwtSettings = appJwtSettings.Value;
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