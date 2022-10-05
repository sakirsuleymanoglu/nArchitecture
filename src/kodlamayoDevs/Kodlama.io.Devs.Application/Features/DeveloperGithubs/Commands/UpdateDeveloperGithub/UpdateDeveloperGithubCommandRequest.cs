using MediatR;

namespace Kodlama.io.Devs.Application.Features.DeveloperGithubs.Commands.UpdateDeveloperGithub
{
    public class UpdateDeveloperGithubCommandRequest : IRequest
    {
        public int Id { get; set; }
        public string Url { get; set; }
    }
}
