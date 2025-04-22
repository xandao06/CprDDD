using Microsoft.EntityFrameworkCore;
using Entities = Domain.Entities;

namespace Data
{
    public class CPRDbContext : DbContext
    {
        public CPRDbContext(DbContextOptions<CPRDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(CPRDbContext).Assembly);
        }

        public virtual DbSet<Entities.Cliente> Clientes { get; set; }
    }
}
