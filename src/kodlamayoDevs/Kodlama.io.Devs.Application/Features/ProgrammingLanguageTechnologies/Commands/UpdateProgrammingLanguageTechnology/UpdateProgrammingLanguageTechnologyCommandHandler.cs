using AutoMapper;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.UpdateProgrammingLanguageTechnology
{
    public class UpdateProgrammingLanguageTechnologyCommandHandler : IRequestHandler<UpdateProgrammingLanguageTechnologyCommandRequest>
    {
        private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
        private readonly ProgrammingLanguageTechnologyRules _programmingLanguageTechnologyRules;
        private readonly IMapper _mapper;

        public UpdateProgrammingLanguageTechnologyCommandHandler(IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository, ProgrammingLanguageTechnologyRules programmingLanguageTechnologyRules, IMapper mapper)
        {
            _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
            _programmingLanguageTechnologyRules = programmingLanguageTechnologyRules;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProgrammingLanguageTechnologyCommandRequest request, CancellationToken cancellationToken)
        {
            ProgrammingLanguageTechnology? programmingLanguageTechnology = await _programmingLanguageTechnologyRepository.GetAsync(x => x.Id == request.Id, enableTracking: false);

            _programmingLanguageTechnologyRules.CheckIfExists(programmingLanguageTechnology);

            await _programmingLanguageTechnologyRules.CheckIfAlreadyExistsAsync(programmingLanguageTechnology!, _mapper.Map<ProgrammingLanguageTechnology>(request));

            _mapper.Map(request, programmingLanguageTechnology);

            await _programmingLanguageTechnologyRepository.UpdateAsync(programmingLanguageTechnology!);

            return Unit.Value;
        }
    }
}
