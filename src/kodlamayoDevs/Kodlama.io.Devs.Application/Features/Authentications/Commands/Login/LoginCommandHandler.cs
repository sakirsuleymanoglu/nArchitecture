using Core.Security.Entities;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Services;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Authentications.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IAccessTokenService _accessTokenService;
        private readonly IRefreshTokenService _refreshTokenService;
        public LoginCommandHandler(IAuthenticationService authenticationService, IAccessTokenService accessTokenService, IRefreshTokenService refreshTokenService)
        {
            _authenticationService = authenticationService;
            _accessTokenService = accessTokenService;
            _refreshTokenService = refreshTokenService;
        }
        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            User user = await _authenticationService.LoginAsync(new()
            {
                Email = request.Email,
                Password = request.Password
            });

            AccessToken accessToken = await _accessTokenService.CreateAsync(user);
            RefreshToken refreshToken = await _refreshTokenService.UpdateAsync(user, request.IpAddress);

            return new()
            {
                AcessToken = accessToken,
                RefreshToken = refreshToken
            };
        }
    }
}
