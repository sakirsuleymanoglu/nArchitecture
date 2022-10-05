using AutoMapper;
using Kodlama.io.Devs.Application.Exceptions.DeveloperGithubs;
using Kodlama.io.Devs.Application.Exceptions.Developers;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.DeveloperGithubs.Commands.CreateDeveloperGithub
{
    public class CreateDeveloperGithubCommandHandler : IRequestHandler<CreateDeveloperGithubCommandRequest, CreateDeveloperGithubCommandResponse>
    {
        private readonly IDeveloperGithubRepository _developerGithubRepository;
        private readonly IDeveloperRepository _developerRepository;
        private readonly RuleManager _ruleManager;
        private readonly IMapper _mapper;
        public CreateDeveloperGithubCommandHandler(IDeveloperGithubRepository developerGithubRepository, IMapper mapper, RuleManager ruleManager, IDeveloperRepository developerRepository)
        {
            _developerGithubRepository = developerGithubRepository;
            _mapper = mapper;
            _ruleManager = ruleManager;
            _developerRepository = developerRepository;
        }

        public async Task<CreateDeveloperGithubCommandResponse> Handle(CreateDeveloperGithubCommandRequest request, CancellationToken cancellationToken)
        {
            await _ruleManager.CheckIfExistsAsync<DeveloperNotFoundException>(operation: async () => await _developerRepository.GetAsync(x => x.Id == request.DeveloperId));

            await _ruleManager.CheckIfAlreadyExistsAsync<DeveloperAlreadyHasAGithubException>(operation: async () => await _developerGithubRepository.GetAsync(x => x.Id == request.DeveloperId, tracking: false));

            await _ruleManager.CheckIfAlreadyExistsAsync<DeveloperGithubAlreadyExistsException>(operation: async () => await _developerGithubRepository.GetAsync(x => x.Url == request.Url, tracking: false));

            DeveloperGithub developerGithub = _mapper.Map<DeveloperGithub>(request);
            DeveloperGithub createdDeveloperGithub = await _developerGithubRepository.AddAsync(developerGithub);
            return _mapper.Map<CreateDeveloperGithubCommandResponse>(createdDeveloperGithub);
        }
    }
}
