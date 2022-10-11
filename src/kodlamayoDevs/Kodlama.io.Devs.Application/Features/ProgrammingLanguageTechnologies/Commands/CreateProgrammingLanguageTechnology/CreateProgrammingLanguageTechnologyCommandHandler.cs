using AutoMapper;
using Core.Application;
using Kodlama.io.Devs.Application.Exceptions.ProgrammingLanguages;
using Kodlama.io.Devs.Application.Exceptions.ProgrammingLanguageTechnologies;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.CreateProgrammingLanguageTechnology
{
    public class CreateProgrammingLanguageTechnologyCommandHandler : IRequestHandler<CreateProgrammingLanguageTechnologyCommandRequest, CreateProgrammingLanguageTechnologyCommandResponse>
    {
        private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly RuleManager _ruleManager;
        private readonly IMapper _mapper;
        public CreateProgrammingLanguageTechnologyCommandHandler(IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository, RuleManager ruleManager, IMapper mapper, IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
            _ruleManager = ruleManager;
            _mapper = mapper;
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task<CreateProgrammingLanguageTechnologyCommandResponse> Handle(CreateProgrammingLanguageTechnologyCommandRequest request, CancellationToken cancellationToken)
        {
            await _ruleManager.CheckIfExistsAsync<ProgrammingLanguageNotFoundException>(operation: async () => await _programmingLanguageRepository.GetAsync(x => x.Id == request.ProgrammingLanguageId, tracking: false));

            await _ruleManager.CheckIfAlreadyExistsAsync<ProgrammingLanguageTechnologyAlreadyExistsException>(operation: async () => await _programmingLanguageTechnologyRepository.GetAsync(x => x.Name == request.Name && x.ProgrammingLanguageId == request.ProgrammingLanguageId));

            ProgrammingLanguageTechnology programmingLanguageTechnology = _mapper.Map<ProgrammingLanguageTechnology>(request);

            ProgrammingLanguageTechnology createdProgrammingLanguageTechnology = await _programmingLanguageTechnologyRepository.AddAsync(programmingLanguageTechnology);
            return _mapper.Map<CreateProgrammingLanguageTechnologyCommandResponse>(createdProgrammingLanguageTechnology);
        }
    }
}
