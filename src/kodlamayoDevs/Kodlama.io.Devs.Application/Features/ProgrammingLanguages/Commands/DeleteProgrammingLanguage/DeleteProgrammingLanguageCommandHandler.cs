﻿using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage
{
    public class DeleteProgrammingLanguageCommandHandler : IRequestHandler<DeleteProgrammingLanguageCommandRequest>
    {
        private readonly ProgrammingLanguageRules _programmingLanguageRules;
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public DeleteProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, ProgrammingLanguageRules programmingLanguageRules)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _programmingLanguageRules = programmingLanguageRules;
        }

        public async Task<Unit> Handle(DeleteProgrammingLanguageCommandRequest request, CancellationToken cancellationToken)
        {
            ProgrammingLanguage? programmingLanguage = await _programmingLanguageRepository.GetAsync(x => x.Id == request.Id, enableTracking: false);

            _programmingLanguageRules.CheckIfExists(programmingLanguage);

            await _programmingLanguageRepository.DeleteAsync(programmingLanguage!);

            return Unit.Value;
        }
    }
}
