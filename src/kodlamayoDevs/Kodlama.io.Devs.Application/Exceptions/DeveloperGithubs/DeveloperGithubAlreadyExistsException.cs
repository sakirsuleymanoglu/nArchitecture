using Core.CrossCuttingConcerns.Exceptions;

namespace Kodlama.io.Devs.Application.Exceptions.DeveloperGithubs
{
    public class DeveloperGithubAlreadyExistsException : BadRequestException
    {
        public DeveloperGithubAlreadyExistsException(string? message = null) : base(message ?? "developer github already exists")
        {

        }
    }
}
