using AutoMapper;
using Kodlama.io.Devs.Application.Exceptions.ProgrammingLanguages;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage
{
    public class CreateProgrammingLanguageCommandHandler : IRequestHandler<CreateProgrammingLanguageCommandRequest, CreateProgrammingLanguageCommandResponse>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly RuleManager _ruleManager;
        private readonly IMapper _mapper;
        public CreateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, RuleManager ruleManager)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _ruleManager = ruleManager;
            _mapper = mapper;
        }

        public async Task<CreateProgrammingLanguageCommandResponse> Handle(CreateProgrammingLanguageCommandRequest request, CancellationToken cancellationToken)
        {
            ProgrammingLanguage programmingLanguage = _mapper.Map<ProgrammingLanguage>(request);

            await _ruleManager.CheckIfAlreadyExistsAsync<ProgrammingLanguageAlreadyExistsException>(operation: async () => await _programmingLanguageRepository.GetAsync(x => x.Name == request.Name));

            ProgrammingLanguage createdProgrammingLanguage = await _programmingLanguageRepository.AddAsync(programmingLanguage);

            return _mapper.Map<CreateProgrammingLanguageCommandResponse>(createdProgrammingLanguage);
        }
    }
}
