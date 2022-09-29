using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.Authentications.Commands.Login
{
    public class LoginAppUserCommandHandler : IRequestHandler<LoginAppUserCommandRequest, LoginAppUserCommandResponse>
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly IAppUserRepository _appUserRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        public LoginAppUserCommandHandler(ITokenHelper tokenHelper, IAppUserRepository appUserRepository, IRefreshTokenRepository refreshTokenRepository, IUserOperationClaimRepository userOperationClaimRepository)
        {
            _tokenHelper = tokenHelper;
            _appUserRepository = appUserRepository;
            _refreshTokenRepository = refreshTokenRepository;
            _userOperationClaimRepository = userOperationClaimRepository;
        }
        public async Task<LoginAppUserCommandResponse> Handle(LoginAppUserCommandRequest request, CancellationToken cancellationToken)
        {
            AppUser? user = await _appUserRepository.GetAsync(x => x.Email == request.Email, enableTracking: false);

            if (user == null)
                throw new Exception();

            bool verifyPasswordHashResult = HashingHelper.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt);
            if (!verifyPasswordHashResult)
                throw new Exception("");

        


            return new();
        }
    }
}
