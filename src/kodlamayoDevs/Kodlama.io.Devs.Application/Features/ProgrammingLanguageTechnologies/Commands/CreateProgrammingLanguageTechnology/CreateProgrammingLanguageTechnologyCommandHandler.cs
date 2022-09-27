using AutoMapper;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.CreateProgrammingLanguageTechnology
{
    public class CreateProgrammingLanguageTechnologyCommandHandler : IRequestHandler<CreateProgrammingLanguageTechnologyCommandRequest, CreateProgrammingLanguageTechnologyCommandResponse>
    {
        private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
        private readonly ProgrammingLanguageTechnologyRules _programmingLanguageTechnologyRules;
        private readonly IMapper _mapper;
        public CreateProgrammingLanguageTechnologyCommandHandler(IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository, ProgrammingLanguageTechnologyRules programmingLanguageTechnologyRules, IMapper mapper)
        {
            _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
            _programmingLanguageTechnologyRules = programmingLanguageTechnologyRules;
            _mapper = mapper;
        }

        public async Task<CreateProgrammingLanguageTechnologyCommandResponse> Handle(CreateProgrammingLanguageTechnologyCommandRequest request, CancellationToken cancellationToken)
        {
            ProgrammingLanguageTechnology programmingLanguageTechnology = _mapper.Map<ProgrammingLanguageTechnology>(request);

            await _programmingLanguageTechnologyRules.CheckIfAlreadyExistsAsync(programmingLanguageTechnology);

            ProgrammingLanguageTechnology addedProgrammingLanguageTechnology = await _programmingLanguageTechnologyRepository.AddAsync(programmingLanguageTechnology);
            return _mapper.Map<CreateProgrammingLanguageTechnologyCommandResponse>(addedProgrammingLanguageTechnology);
        }
    }
}
