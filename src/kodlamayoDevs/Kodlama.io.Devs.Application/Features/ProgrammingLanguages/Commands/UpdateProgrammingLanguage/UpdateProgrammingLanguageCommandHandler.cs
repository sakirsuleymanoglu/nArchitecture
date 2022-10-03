using AutoMapper;
using Kodlama.io.Devs.Application.Exceptions.ProgrammingLanguages;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguageCommandHandler : IRequestHandler<UpdateProgrammingLanguageCommandRequest>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly RuleManager _ruleManager;
        private readonly IMapper _mapper;
        public UpdateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, RuleManager ruleManager, IMapper mapper)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _ruleManager = ruleManager;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProgrammingLanguageCommandRequest request, CancellationToken cancellationToken)
        {
            ProgrammingLanguage? programmingLanguage = await _programmingLanguageRepository.GetAsync(x => x.Id == request.Id, enableTracking: false);

            _ruleManager.CheckIfExists<ProgrammingLanguageNotFoundException>(operation: () => programmingLanguage);

            await _ruleManager.CheckIfAlreadyExistsAsync<ProgrammingLanguageAlreadyExistsException>(operation: async () =>
            {
                if (programmingLanguage!.Name != request.Name)
                    return await _programmingLanguageRepository.GetAsync(x => x.Name == request.Name);

                return null;
            });

            _mapper.Map(request, programmingLanguage);

            await _programmingLanguageRepository.UpdateAsync(programmingLanguage!);

            return Unit.Value;
        }
    }
}
