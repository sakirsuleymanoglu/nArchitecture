using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.CreateProgrammingLanguageTechnology
{
    public class CreateProgrammingLanguageTechnologyCommandRequest : IRequest<CreateProgrammingLanguageTechnologyCommandResponse>, ISecuredRequest
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }

        public string[] Roles => new[] { "CreateProgrammingLanguageTechnology" };
    }
}
