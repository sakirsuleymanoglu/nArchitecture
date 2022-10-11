using Core.CrossCuttingConcerns.Exceptions;

namespace Kodlama.io.Devs.Application.Exceptions.Developers
{
    public class DeveloperAlreadyHasAGithubException : BadRequestException
    {
        public DeveloperAlreadyHasAGithubException(string? message = null) : base(message ?? "Developer already has a github")
        {

        }
    }
}
