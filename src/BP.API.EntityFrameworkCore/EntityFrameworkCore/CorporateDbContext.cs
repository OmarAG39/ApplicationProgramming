using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BP.API.Entity;


namespace BP.API.EntityFrameworkCore
{
    public class CorporateDbContext : AbpDbContext
    {
        ////Add DbSet properties for your entities...
        public DbSet<AuditLog> AuditLog { get; set; }
        public DbSet<AuditDescription> AuditDescription { get; set; }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Cuenta> Cuenta { get; set; }
        public DbSet<Movimientos> Movimientos { get; set; }

        public CorporateDbContext(DbContextOptions<CorporateDbContext> options) 
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            

        }
    }
}
