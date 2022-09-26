using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage
{
    public class CreateProgrammingLanguageCommandRequest : IRequest<CreateProgrammingLanguageCommandResponse>
    {
        public string Name { get; set; }
    }
}
