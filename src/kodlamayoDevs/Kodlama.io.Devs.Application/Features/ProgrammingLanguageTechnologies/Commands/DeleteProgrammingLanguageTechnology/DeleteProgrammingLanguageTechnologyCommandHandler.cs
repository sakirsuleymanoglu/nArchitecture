using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.DeleteProgrammingLanguageTechnology
{
    public class DeleteProgrammingLanguageTechnologyCommandHandler : IRequestHandler<DeleteProgrammingLanguageTechnologyCommandRequest>
    {
        private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
        private readonly ProgrammingLanguageTechnologyRules _programmingLanguageTechnologyRules;

        public DeleteProgrammingLanguageTechnologyCommandHandler(IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository, ProgrammingLanguageTechnologyRules programmingLanguageTechnologyRules)
        {
            _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
            _programmingLanguageTechnologyRules = programmingLanguageTechnologyRules;
        }

        public async Task<Unit> Handle(DeleteProgrammingLanguageTechnologyCommandRequest request, CancellationToken cancellationToken)
        {
            ProgrammingLanguageTechnology? programmingLanguageTechnology = await _programmingLanguageTechnologyRepository.GetAsync(x => x.Id == request.Id, enableTracking: false);

            _programmingLanguageTechnologyRules.CheckIfExists(programmingLanguageTechnology);

            await _programmingLanguageTechnologyRepository.DeleteAsync(programmingLanguageTechnology!);

            return Unit.Value;
        }
    }
}
