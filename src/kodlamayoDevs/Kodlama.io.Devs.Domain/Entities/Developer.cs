using Core.Persistence.Repositories;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class Developer : Entity
    {
        public AppUser AppUser { get; set; }
        public DeveloperGithub DeveloperGithub { get; set; }
    }
}
