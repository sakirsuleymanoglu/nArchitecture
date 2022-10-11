using Core.Application;
using Kodlama.io.Devs.Application.Exceptions.DeveloperGithubs;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.DeveloperGithubs.Commands.DeleteDeveloperGithub
{
    public class DeleteDeveloperGithubCommandHandler : IRequestHandler<DeleteDeveloperGithubCommandRequest>
    {
        private readonly RuleManager _ruleManager;

        private readonly IDeveloperGithubRepository _developerGithubRepository;
        public DeleteDeveloperGithubCommandHandler(RuleManager ruleManager, IDeveloperGithubRepository developerGithubRepository)
        {
            _ruleManager = ruleManager;
            _developerGithubRepository = developerGithubRepository;
        }
        public async Task<Unit> Handle(DeleteDeveloperGithubCommandRequest request, CancellationToken cancellationToken)
        {
            DeveloperGithub? developerGithub = await _developerGithubRepository.GetAsync(x => x.Id == request.Id, tracking: false);

            _ruleManager.CheckIfExists<DeveloperGithubNotFoundException>(operation: () => developerGithub);

            await _developerGithubRepository.DeleteAsync(developerGithub!);

            return Unit.Value;
        }
    }
}
