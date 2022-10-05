namespace Kodlama.io.Devs.Application.Exceptions.Developers
{
    public class DeveloperAlreadyHasAGithubException : BadRequestException
    {
        public DeveloperAlreadyHasAGithubException() : base("Developer already has a github")
        {

        }
    }
}
