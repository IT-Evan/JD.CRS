using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace JD.CRS.EntityFrameworkCore
{
    public static class CRSDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<CRSDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<CRSDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
