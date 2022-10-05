using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.DeveloperGithubs.Commands.CreateDeveloperGithub
{
    public class CreateDeveloperGithubCommandRequest : IRequest<CreateDeveloperGithubCommandResponse>, ISecuredRequest
    {
        public int DeveloperId { get; set; }
        public string Url { get; set; }

        public string[] Roles => new[] { "CreateDeveloperGithub" };
    }
}
