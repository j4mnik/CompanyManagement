using CompanyManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Infrastructure.Persistence
{
    public class CompanyManagementDbContext : IdentityDbContext
    {

        public CompanyManagementDbContext(DbContextOptions<CompanyManagementDbContext> options) : base(options)
        {

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> Tasks { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Department>()
                .HasMany(c => c.Projects)
                .WithOne(s => s.Department)
                .HasForeignKey(s => s.DepartmentId);

            builder.Entity<Employee>()
                .HasOne(u => u.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(u => u.DepartmentId);

            builder.Entity<Domain.Entities.Project>()
                .HasMany(c => c.Tasks)
                .WithOne(s => s.Project)
                .HasForeignKey(s => s.ProjectId);

            builder.Entity<ProjectTask>()
                .HasOne(e => e.Employee)
                .WithMany(t => t.Tasks)
                .HasForeignKey(e => e.EmployeeId);
        }
    }
}