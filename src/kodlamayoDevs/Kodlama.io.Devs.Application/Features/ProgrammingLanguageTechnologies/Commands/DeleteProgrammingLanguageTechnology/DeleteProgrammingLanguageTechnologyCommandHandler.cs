using Core.Application;
using Kodlama.io.Devs.Application.Exceptions.ProgrammingLanguageTechnologies;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.DeleteProgrammingLanguageTechnology
{
    public class DeleteProgrammingLanguageTechnologyCommandHandler : IRequestHandler<DeleteProgrammingLanguageTechnologyCommandRequest>
    {
        private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
        private readonly RuleManager _ruleManager;

        public DeleteProgrammingLanguageTechnologyCommandHandler(IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository, RuleManager ruleManager)
        {
            _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
            _ruleManager = ruleManager;
        }

        public async Task<Unit> Handle(DeleteProgrammingLanguageTechnologyCommandRequest request, CancellationToken cancellationToken)
        {
            ProgrammingLanguageTechnology? programmingLanguageTechnology = await _programmingLanguageTechnologyRepository.GetAsync(x => x.Id == request.Id, tracking: false);

            _ruleManager.CheckIfExists<ProgrammingLanguageTechnologyNotFoundException>(operation: () => programmingLanguageTechnology);

            await _programmingLanguageTechnologyRepository.DeleteAsync(programmingLanguageTechnology!);

            return Unit.Value;
        }
    }
}
