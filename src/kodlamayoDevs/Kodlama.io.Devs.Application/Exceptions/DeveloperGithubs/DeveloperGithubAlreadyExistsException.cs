namespace Kodlama.io.Devs.Application.Exceptions.DeveloperGithubs
{
    public class DeveloperGithubAlreadyExistsException : BadRequestException
    {
        public DeveloperGithubAlreadyExistsException() : base("developer github already exists")
        {

        }
    }
}
