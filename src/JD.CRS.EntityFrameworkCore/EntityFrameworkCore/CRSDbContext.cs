using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using JD.CRS.Authorization.Roles;
using JD.CRS.Authorization.Users;
using JD.CRS.MultiTenancy;
using JD.CRS.Entitys;

namespace JD.CRS.EntityFrameworkCore
{
    public class CRSDbContext : AbpZeroDbContext<Tenant, Role, User, CRSDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public CRSDbContext(DbContextOptions<CRSDbContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Office> Office { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<DepartmentInstructor> DepartmentInstructor { get; set; }
        public DbSet<DepartmentCourse> DepartmentCourse { get; set; }        
        public DbSet<OfficeInstructor> OfficeInstructor { get; set; }
        public DbSet<InstructorCourse> InstructorCourse { get; set; }
        public DbSet<StudentCourse> StudentCourse { get; set; }

    }
}
