using Core.Persistence.Repositories;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Persistence.Contexts;

namespace Kodlama.io.Devs.Persistence.Repositories
{
    public class DeveloperGithubRepository : EfRepositoryBase<DeveloperGithub, ApplicationDbContext>, IDeveloperGithubRepository
    {
        public DeveloperGithubRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
