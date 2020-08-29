using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BarDg.Api.Authorizations
{
    public static class AuthUserExtension
    {
        public static async Task<bool> UserExists<TUser>(this UserManager<TUser> userManager, string userName) 
            where TUser : IdentityUser
        {
            return await userManager.FindByNameAsync(userName) != null;
        }
    }
}