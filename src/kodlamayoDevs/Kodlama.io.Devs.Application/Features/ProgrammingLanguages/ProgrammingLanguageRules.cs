using Kodlama.io.Devs.Application.Exceptions.ProgrammingLanguages;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages
{
    public class ProgrammingLanguageRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguageRules(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task CheckIfAlreadyExistsAsync(ProgrammingLanguage programmingLanguage)
        {
            bool result = await _programmingLanguageRepository.AnyAsync(x => x.Name == programmingLanguage.Name);
            if (result)
                throw new ProgrammingLanguageAlreadyExistsException();
        }

        public async Task CheckIfAlreadyExistsAsync(ProgrammingLanguage programmingLanguage, ProgrammingLanguage updatedProgrammingLanguage)
        {
            if (programmingLanguage.Name != updatedProgrammingLanguage.Name)
                await CheckIfAlreadyExistsAsync(updatedProgrammingLanguage);
        }

        public void CheckIfExists(ProgrammingLanguage? programmingLanguage)
        {
            if (programmingLanguage == null)
                throw new ProgrammingLanguageNotFoundException();
        }
    }
}
