namespace Kodlama.io.Devs.Application.Exceptions.DeveloperGithubs
{
    public class DeveloperGithubNotFoundException : NotFoundException
    {
        public DeveloperGithubNotFoundException() : base("developer github not found")
        {
        }
    }
}
