using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage
{
    public class DeleteProgrammingLanguageCommandRequest : IRequest, ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles => new[] { "DeleteProgrammingLanguage" };
    }
}
