using Core.Application;
using Core.Security.Entities;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Exceptions.RefreshTokens;
using Kodlama.io.Devs.Application.Services;
using Kodlama.io.Devs.Application.Services.Repositories;

namespace Kodlama.io.Devs.Persistence.Services
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly RuleManager _ruleManager;

        public RefreshTokenService(IRefreshTokenRepository refreshTokenRepository, ITokenHelper tokenHelper, RuleManager ruleManager)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _tokenHelper = tokenHelper;
            _ruleManager = ruleManager;
        }

        public async Task<RefreshToken> AddAsync(User user, string ipAddress)
        {
            RefreshToken refreshToken = _tokenHelper.CreateRefreshToken(user, ipAddress);
            return await _refreshTokenRepository.AddAsync(refreshToken);
        }

        public async Task<RefreshToken> UpdateAsync(User user, string ipAddress)
        {
            RefreshToken? refreshToken = await _refreshTokenRepository.GetAsync(x => x.UserId == user.Id, tracking: false);

            _ruleManager.CheckIfExists<RefreshTokenNotFoundException>(operation: () => refreshToken);

            RefreshToken newRefreshToken = _tokenHelper.CreateRefreshToken(user, ipAddress);

            refreshToken!.Expires = newRefreshToken.Expires;
            refreshToken.CreatedByIp = newRefreshToken.CreatedByIp;
            refreshToken.RevokedByIp = newRefreshToken.RevokedByIp;
            refreshToken.ReplacedByToken = newRefreshToken.ReplacedByToken;
            refreshToken.Revoked = newRefreshToken.Revoked;
            refreshToken.Created = newRefreshToken.Created;
            refreshToken.ReasonRevoked = newRefreshToken.ReasonRevoked;
            refreshToken.Token = newRefreshToken.Token;

            await _refreshTokenRepository.UpdateAsync(refreshToken);

            return newRefreshToken;
        }
    }
}
