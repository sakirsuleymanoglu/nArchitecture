using MediatR;

namespace Kodlama.io.Devs.Application.Features.DeveloperGithubs.Commands.CreateDeveloperGithub
{
    public class CreateDeveloperGithubCommandRequest : IRequest<CreateDeveloperGithubCommandResponse>
    {
        public int DeveloperId { get; set; }
        public string Url { get; set; }
    }
}
