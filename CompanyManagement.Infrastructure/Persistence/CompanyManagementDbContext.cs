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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
