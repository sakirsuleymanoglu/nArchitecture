using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage
{
    public class CreateProgrammingLanguageCommandRequest : IRequest<CreateProgrammingLanguageCommandResponse>, ISecuredRequest
    {
        public string Name { get; set; }

        public string[] Roles => new[] { "CreateProgrammingLanguage" };
    }
}
