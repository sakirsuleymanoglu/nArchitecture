using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Kodlama.io.Devs.Application.Features.Authentications.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly IAppUserRepository _appUserRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        public LoginCommandHandler(ITokenHelper tokenHelper, IAppUserRepository appUserRepository, IRefreshTokenRepository refreshTokenRepository, IUserOperationClaimRepository userOperationClaimRepository)
        {
            _tokenHelper = tokenHelper;
            _appUserRepository = appUserRepository;
            _refreshTokenRepository = refreshTokenRepository;
            _userOperationClaimRepository = userOperationClaimRepository;
        }
        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            AppUser? user = await _appUserRepository.GetAsync(x => x.Email == request.Email, tracking: false);

            if (user == null)
                throw new Exception();

            bool verifyPasswordHashResult = HashingHelper.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt);
            if (!verifyPasswordHashResult)
                throw new Exception("");

            IEnumerable<UserOperationClaim> userOperationClaims = await _userOperationClaimRepository.GetListWithoutPaginateAsync(x => x.UserId == user.Id, include: x => x.Include(x => x.OperationClaim), tracking: false, disableTrackingWithIdentityResolution: true);

            AccessToken accessToken = _tokenHelper.CreateToken(user, userOperationClaims.Select(x => new OperationClaim { Id = x.OperationClaim.Id, Name = x.OperationClaim.Name }).ToList());

            IPAddress? ipAddress = (await Dns.GetHostEntryAsync(Dns.GetHostName())).AddressList.FirstOrDefault();

            RefreshToken refreshToken = _tokenHelper.CreateRefreshToken(user, ipAddress?.ToString() ?? string.Empty);

            RefreshToken? userRefreshToken = await _refreshTokenRepository.GetAsync(x => x.UserId == user.Id, tracking: false);

            if (userRefreshToken != null)
                await _refreshTokenRepository.AddAsync(refreshToken);
            else
                await _refreshTokenRepository.UpdateAsync(refreshToken);

            return new LoginCommandResponse { AcessToken = accessToken.Token, RefreshToken = refreshToken.Token };
        }
    }
}
