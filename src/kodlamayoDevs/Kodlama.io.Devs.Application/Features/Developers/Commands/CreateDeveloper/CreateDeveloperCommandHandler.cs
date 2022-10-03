using AutoMapper;
using Core.Security.Hashing;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Developers.Commands.CreateDeveloper
{
    public class CreateDeveloperCommandHandler : IRequestHandler<CreateDeveloperCommandRequest, CreateDeveloperCommandResponse>
    {
        private readonly IDeveloperRepository _developerRepository;
        private readonly IAppUserRepository _appUserRepository;
        private readonly IMapper _mapper;
        public CreateDeveloperCommandHandler(IDeveloperRepository developerRepository, IAppUserRepository appUserRepository, IMapper mapper)
        {
            _developerRepository = developerRepository;
            _appUserRepository = appUserRepository;
            _mapper = mapper;
        }
        public async Task<CreateDeveloperCommandResponse> Handle(CreateDeveloperCommandRequest request, CancellationToken cancellationToken)
        {
            HashingHelper.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            AppUser addedAppUser = await _appUserRepository.AddAsync(new AppUser
            {
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true,
            });

            await _developerRepository.AddAsync(new Developer
            {
                Id = addedAppUser.Id
            });

            return _mapper.Map<CreateDeveloperCommandResponse>(addedAppUser);
        }
    }
}
