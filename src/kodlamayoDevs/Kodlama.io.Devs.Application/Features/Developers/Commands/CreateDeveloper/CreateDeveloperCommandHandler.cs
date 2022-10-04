using Core.Security.Entities;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Services;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Developers.Commands.CreateDeveloper
{
    public class CreateDeveloperCommandHandler : IRequestHandler<CreateDeveloperCommandRequest, CreateDeveloperCommandResponse>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IAccessTokenService _accessTokenService;
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly IDeveloperRepository _developerRepository;
        public CreateDeveloperCommandHandler(IAuthenticationService authenticationService, IAccessTokenService accessTokenService, IRefreshTokenService refreshTokenService, IDeveloperRepository developerRepository)
        {
            _authenticationService = authenticationService;
            _accessTokenService = accessTokenService;
            _refreshTokenService = refreshTokenService;
            _developerRepository = developerRepository;
        }
        public async Task<CreateDeveloperCommandResponse> Handle(CreateDeveloperCommandRequest request, CancellationToken cancellationToken)
        {
            User user = await _authenticationService.RegisterAsync(new()
            {
                Email = request.Email,
                Password = request.Password
            });

            Developer developer = new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                Id = user.Id
            };

            await _developerRepository.AddAsync(developer);

            AccessToken accessToken = await _accessTokenService.CreateAsync(user);
            RefreshToken refreshToken = await _refreshTokenService.AddAsync(user, request.IpAddress);


            return new() { AccessToken = accessToken, RefreshToken = refreshToken };
        }
    }
}
