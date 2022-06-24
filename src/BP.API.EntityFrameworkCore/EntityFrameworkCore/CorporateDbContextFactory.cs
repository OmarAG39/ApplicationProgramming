using BP.API.Configuration;
using BP.API.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BP.API.EntityFrameworkCore
{
    /* This class is needed to run EF Core PMC commands. Not used anywhere else */
    public class CorporateDbContextFactory : IDesignTimeDbContextFactory<CorporateDbContext>
    {
        public CorporateDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CorporateDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DbContextOptionsConfigurer.Configure(
                builder,
                configuration.GetConnectionString(CorporateConsts.ConnectionStringName)
            );

            return new CorporateDbContext(builder.Options);
        }
    }
}