using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage
{
    public class CreateProgrammingLanguageCommandRequestValidator : AbstractValidator<CreateProgrammingLanguageCommandRequest>
    {
        public CreateProgrammingLanguageCommandRequestValidator()
        {
            RuleFor(x => x.Name).NotNull();
        }
    }
}
