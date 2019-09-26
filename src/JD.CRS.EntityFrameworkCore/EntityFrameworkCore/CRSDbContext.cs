using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using JD.CRS.Authorization.Roles;
using JD.CRS.Authorization.Users;
using JD.CRS.MultiTenancy;

namespace JD.CRS.EntityFrameworkCore
{
    public class CRSDbContext : AbpZeroDbContext<Tenant, Role, User, CRSDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public CRSDbContext(DbContextOptions<CRSDbContext> options)
            : base(options)
        {
        }
    }
}
