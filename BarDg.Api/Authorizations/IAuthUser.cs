using System.Threading.Tasks;
using NetDevPack.Identity.Jwt.Model;

namespace BarDg.Api.Authorizations
{
    public interface IAuthUser
    {
        Task<bool> CreateDefaultUserAdmin(string userName, string password);
        Task<UserResponse<string>> LoginAsync(LoginRequest loginUser);
    }
}