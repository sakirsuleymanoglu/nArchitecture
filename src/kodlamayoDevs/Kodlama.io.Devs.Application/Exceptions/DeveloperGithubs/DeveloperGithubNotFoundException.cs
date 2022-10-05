namespace Kodlama.io.Devs.Application.Exceptions.DeveloperGithubs
{
    public class DeveloperGithubNotFoundException : NotFoundException
    {
        public DeveloperGithubNotFoundException(string? message = null) : base(message ?? "developer github not found")
        {

        }
    }
}
