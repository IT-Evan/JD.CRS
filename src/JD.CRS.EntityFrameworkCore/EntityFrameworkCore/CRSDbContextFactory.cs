using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using JD.CRS.Configuration;
using JD.CRS.Web;

namespace JD.CRS.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class CRSDbContextFactory : IDesignTimeDbContextFactory<CRSDbContext>
    {
        public CRSDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CRSDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            CRSDbContextConfigurer.Configure(builder, configuration.GetConnectionString(CRSConsts.ConnectionStringName));

            return new CRSDbContext(builder.Options);
        }
    }
}
