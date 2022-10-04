using Core.Security.Entities;
using Core.Security.JWT;

namespace Kodlama.io.Devs.Application.Services
{
    public interface IAccessTokenService
    {
        Task<AccessToken> CreateAsync(User user);
    }
}
