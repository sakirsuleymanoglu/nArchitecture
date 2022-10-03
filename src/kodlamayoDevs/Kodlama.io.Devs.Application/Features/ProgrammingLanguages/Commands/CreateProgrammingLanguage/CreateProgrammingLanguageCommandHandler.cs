using AutoMapper;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage
{
    public class CreateProgrammingLanguageCommandHandler : IRequestHandler<CreateProgrammingLanguageCommandRequest, CreateProgrammingLanguageCommandResponse>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly ProgrammingLanguageRules _programmingLanguageRules;
        private readonly IMapper _mapper;
        public CreateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageRules programmingLanguageRules)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _programmingLanguageRules = programmingLanguageRules;
            _mapper = mapper;
        }

        public async Task<CreateProgrammingLanguageCommandResponse> Handle(CreateProgrammingLanguageCommandRequest request, CancellationToken cancellationToken)
        {
            ProgrammingLanguage programmingLanguage = _mapper.Map<ProgrammingLanguage>(request);

            await _programmingLanguageRules.CheckIfAlreadyExistsAsync(programmingLanguage);

            ProgrammingLanguage createdProgrammingLanguage = await _programmingLanguageRepository.AddAsync(programmingLanguage);

            return _mapper.Map<CreateProgrammingLanguageCommandResponse>(createdProgrammingLanguage);
        }
    }
}
