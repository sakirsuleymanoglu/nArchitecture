using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.DeveloperGithubs.Commands.DeleteDeveloperGithub
{
    public class DeleteDeveloperGithubCommandRequest : IRequest, ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles => new[] { "DeleteDeveloperGithub" };
    }
}
