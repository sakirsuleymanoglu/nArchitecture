using AutoMapper;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguageCommandHandler : IRequestHandler<UpdateProgrammingLanguageCommandRequest>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly ProgrammingLanguageRules _programmingLanguageRules;
        private readonly IMapper _mapper;
        public UpdateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, ProgrammingLanguageRules programmingLanguageRules, IMapper mapper)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _programmingLanguageRules = programmingLanguageRules;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProgrammingLanguageCommandRequest request, CancellationToken cancellationToken)
        {
            ProgrammingLanguage? programmingLanguage = await _programmingLanguageRepository.GetAsync(x => x.Id == request.Id, enableTracking: false);

            _programmingLanguageRules.CheckIfExists(programmingLanguage);

            if (request.Name != programmingLanguage!.Name)
                await _programmingLanguageRules.CheckIfAlreadyExistsAsync(request.Name);

            _mapper.Map(request, programmingLanguage);

            await _programmingLanguageRepository.UpdateAsync(programmingLanguage!);

            return Unit.Value;
        }
    }
}
