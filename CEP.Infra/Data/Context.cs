using CEP.Domain.Entities;
using CEP.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace CEP.Infra.Data
{
    public class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> builderOptions) : base(builderOptions)
        {
        }
        
        public DbSet<Cep> Ceps { get; set; }
        
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Cep>().MappingCep();
            base.OnModelCreating(builder);
        }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
            // optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=myp;Password=batata123;Database=cep-project;");
        // }
    }
}