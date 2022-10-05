using MediatR;

namespace Kodlama.io.Devs.Application.Features.DeveloperGithubs.Commands.DeleteDeveloperGithub
{
    public class DeleteDeveloperGithubCommandRequest : IRequest
    {
        public int Id { get; set; }
    }
}
