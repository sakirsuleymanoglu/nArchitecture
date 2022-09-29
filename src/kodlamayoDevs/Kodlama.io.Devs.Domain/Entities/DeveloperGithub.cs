using Core.Persistence.Repositories;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class DeveloperGithub : Entity
    {
        public string Url { get; set; }
        public Developer Developer { get; set; }
    }
}
