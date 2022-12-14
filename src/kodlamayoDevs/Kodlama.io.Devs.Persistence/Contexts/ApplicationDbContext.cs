using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Kodlama.io.Devs.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<ProgrammingLanguage> ProgrammingLanguages => Set<ProgrammingLanguage>();
        public DbSet<ProgrammingLanguageTechnology> ProgrammingLanguageTechnologies => Set<ProgrammingLanguageTechnology>();
        public DbSet<Developer> Developers => Set<Developer>();
        public DbSet<DeveloperGithub> DeveloperGithubs => Set<DeveloperGithub>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
