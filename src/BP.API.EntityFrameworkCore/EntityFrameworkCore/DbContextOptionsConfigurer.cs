using Microsoft.EntityFrameworkCore;

namespace BP.API.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {
        public static void Configure(
            DbContextOptionsBuilder<CorporateDbContext> dbContextOptions, 
            string connectionString
            )
        {
            /* This is the single point to configure DbContextOptions for CorporateDbContext */
            dbContextOptions.UseSqlServer(connectionString);
        }
    }
}
