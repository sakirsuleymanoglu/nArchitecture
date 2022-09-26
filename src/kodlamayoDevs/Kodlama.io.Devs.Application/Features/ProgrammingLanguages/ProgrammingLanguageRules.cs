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

        public async Task CheckIfAlreadyExistsAsync(string name)
        {
            bool result = await _programmingLanguageRepository.AnyAsync(x => x.Name == name);
            if (result)
                throw new ProgrammingLanguageAlreadyExistsException();
        }

        public void CheckIfExists(ProgrammingLanguage? programmingLanguage)
        {
            if (programmingLanguage == null)
                throw new ProgrammingLanguageNotFoundException();
        }
    }
}
