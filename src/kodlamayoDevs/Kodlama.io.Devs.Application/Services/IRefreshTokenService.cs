using Core.Security.Entities;

namespace Kodlama.io.Devs.Application.Services
{
    public interface IRefreshTokenService
    {
        Task<RefreshToken> AddAsync(User user, string ipAddress);
        Task<RefreshToken> UpdateAsync(User user, string ipAddress);
    }
}
