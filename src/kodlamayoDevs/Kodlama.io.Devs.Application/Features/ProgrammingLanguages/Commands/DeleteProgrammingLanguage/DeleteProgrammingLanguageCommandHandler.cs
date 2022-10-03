using Kodlama.io.Devs.Application.Exceptions.ProgrammingLanguages;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage
{
    public class DeleteProgrammingLanguageCommandHandler : IRequestHandler<DeleteProgrammingLanguageCommandRequest>
    {
        private readonly RuleManager _ruleManager;
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public DeleteProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, RuleManager ruleManager)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _ruleManager = ruleManager;
        }

        public async Task<Unit> Handle(DeleteProgrammingLanguageCommandRequest request, CancellationToken cancellationToken)
        {
            ProgrammingLanguage? programmingLanguage = await _programmingLanguageRepository.GetAsync(x => x.Id == request.Id, enableTracking: false);

            _ruleManager.CheckIfExists<ProgrammingLanguageNotFoundException>(operation: () => programmingLanguage);

            await _programmingLanguageRepository.DeleteAsync(programmingLanguage!);

            return Unit.Value;
        }
    }
}
