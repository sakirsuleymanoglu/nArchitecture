using Core.Security.Entities;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Services;
using Kodlama.io.Devs.Application.Services.Repositories;

namespace Kodlama.io.Devs.Persistence.Services
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly ITokenHelper _tokenHelper;

        public RefreshTokenService(IRefreshTokenRepository refreshTokenRepository, ITokenHelper tokenHelper)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _tokenHelper = tokenHelper;
        }

        public async Task<RefreshToken> AddAsync(User user, string ipAddress)
        {
            RefreshToken refreshToken = _tokenHelper.CreateRefreshToken(user, ipAddress);
            return await _refreshTokenRepository.AddAsync(refreshToken);
        }
    }
}
