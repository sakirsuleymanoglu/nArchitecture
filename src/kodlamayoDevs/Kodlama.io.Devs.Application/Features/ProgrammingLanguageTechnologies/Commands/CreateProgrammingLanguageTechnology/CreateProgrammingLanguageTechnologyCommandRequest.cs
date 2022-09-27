using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.CreateProgrammingLanguageTechnology
{
    public class CreateProgrammingLanguageTechnologyCommandRequest : IRequest<CreateProgrammingLanguageTechnologyCommandResponse>
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
    }
}
