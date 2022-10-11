using AutoMapper;
using Core.Application;
using Kodlama.io.Devs.Application.Exceptions.ProgrammingLanguageTechnologies;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.UpdateProgrammingLanguageTechnology
{
    public class UpdateProgrammingLanguageTechnologyCommandHandler : IRequestHandler<UpdateProgrammingLanguageTechnologyCommandRequest>
    {
        private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
        private readonly RuleManager _ruleManager;
        private readonly IMapper _mapper;

        public UpdateProgrammingLanguageTechnologyCommandHandler(IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository, RuleManager ruleManager, IMapper mapper)
        {
            _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
            _ruleManager = ruleManager;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProgrammingLanguageTechnologyCommandRequest request, CancellationToken cancellationToken)
        {
            ProgrammingLanguageTechnology? programmingLanguageTechnology = await _programmingLanguageTechnologyRepository.GetAsync(x => x.Id == request.Id, tracking: false);

            _ruleManager.CheckIfExists<ProgrammingLanguageTechnologyNotFoundException>(() => programmingLanguageTechnology);

            await _ruleManager.CheckIfAlreadyExistsAsync<ProgrammingLanguageTechnologyAlreadyExistsException>(operation: async () =>
            {
                if (request.ProgrammingLanguageId != programmingLanguageTechnology!.ProgrammingLanguageId || request.Name != programmingLanguageTechnology.Name)
                    return await _programmingLanguageTechnologyRepository.GetAsync(x => x.Name == request.Name && x.ProgrammingLanguageId == request.ProgrammingLanguageId);

                return null;
            });

            _mapper.Map(request, programmingLanguageTechnology);

            await _programmingLanguageTechnologyRepository.UpdateAsync(programmingLanguageTechnology!);

            return Unit.Value;
        }
    }
}
