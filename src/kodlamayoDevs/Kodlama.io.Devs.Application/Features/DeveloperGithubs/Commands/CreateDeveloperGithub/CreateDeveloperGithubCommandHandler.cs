using MediatR;

namespace Kodlama.io.Devs.Application.Features.DeveloperGithubs.Commands.CreateDeveloperGithub
{
    public class CreateDeveloperGithubCommandHandler : IRequestHandler<CreateDeveloperGithubCommandRequest, CreateDeveloperGithubCommandResponse>
    {
        public Task<CreateDeveloperGithubCommandResponse> Handle(CreateDeveloperGithubCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
