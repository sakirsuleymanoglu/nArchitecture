using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.DeveloperGithubs.Commands.UpdateDeveloperGithub
{
    public class UpdateDeveloperGithubCommandRequest : IRequest, ISecuredRequest
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public string[] Roles => new[] { "UpdateDeveloperGithub" };
    }
}
