using AutoMapper;
using Core.Application;
using Kodlama.io.Devs.Application.Exceptions.DeveloperGithubs;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.DeveloperGithubs.Commands.UpdateDeveloperGithub
{
    public class UpdateDeveloperGithubCommandHandler : IRequestHandler<UpdateDeveloperGithubCommandRequest>
    {
        private readonly IDeveloperGithubRepository _developerGithubRepository;
        private readonly IMapper _mapper;
        private readonly RuleManager _ruleManager;

        public UpdateDeveloperGithubCommandHandler(IDeveloperGithubRepository developerGithubRepository, IMapper mapper, RuleManager ruleManager)
        {
            _developerGithubRepository = developerGithubRepository;
            _mapper = mapper;
            _ruleManager = ruleManager;
        }

        public async Task<Unit> Handle(UpdateDeveloperGithubCommandRequest request, CancellationToken cancellationToken)
        {
            DeveloperGithub? developerGithub = await _developerGithubRepository.GetAsync(x => x.Id == request.Id, tracking: false);

            _ruleManager.CheckIfExists<DeveloperGithubNotFoundException>(operation: () => developerGithub);

            await _ruleManager.CheckIfAlreadyExistsAsync<DeveloperGithubAlreadyExistsException>(operation: async () =>
            {
                if (request.Url != developerGithub!.Url)
                    return await _developerGithubRepository.GetAsync(x => x.Url == request.Url);
                return null;
            });

            _mapper.Map(request, developerGithub);

            await _developerGithubRepository.UpdateAsync(developerGithub!);

            return Unit.Value;
        }
    }
}
