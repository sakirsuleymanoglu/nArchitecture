using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.DeleteProgrammingLanguageTechnology
{
    public class DeleteProgrammingLanguageTechnologyCommandRequest : IRequest, ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles => new[] { "DeleteProgrammingLanguageTechnology" };
    }
}
