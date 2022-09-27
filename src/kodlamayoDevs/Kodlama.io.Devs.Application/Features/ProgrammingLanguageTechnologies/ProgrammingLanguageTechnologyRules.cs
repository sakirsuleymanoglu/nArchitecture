using Kodlama.io.Devs.Application.Exceptions.ProgrammingLanguageTechnologies;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies
{
    public class ProgrammingLanguageTechnologyRules
    {
        private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
        public ProgrammingLanguageTechnologyRules(IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository)
        {
            _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
        }
        public void CheckIfExists(ProgrammingLanguageTechnology? programmingLanguageTechnology)
        {
            if (programmingLanguageTechnology == null)
                throw new ProgrammingLanguageTechnologyNotFoundException();
        }
        public async Task CheckIfAlreadyExistsAsync(ProgrammingLanguageTechnology programmingLanguageTechnology)
        {
            bool result = await _programmingLanguageTechnologyRepository.AnyAsync(x => x.ProgrammingLanguageId == programmingLanguageTechnology.ProgrammingLanguageId && x.Name == programmingLanguageTechnology.Name);
            if (result)
                throw new ProgrammingLanguageTechnologyAlreadyExistsException();
        }

        public async Task CheckIfAlreadyExistsAsync(ProgrammingLanguageTechnology programmingLanguageTechnology, ProgrammingLanguageTechnology updatedProgrammingLanguageTechnology)
        {
            if (programmingLanguageTechnology.ProgrammingLanguageId != updatedProgrammingLanguageTechnology.ProgrammingLanguageId || programmingLanguageTechnology.Name != updatedProgrammingLanguageTechnology.Name)
                await CheckIfAlreadyExistsAsync(updatedProgrammingLanguageTechnology);
        }
    }
}
