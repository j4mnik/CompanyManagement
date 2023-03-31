using CompanyManagement.Domain.Interfaces;
using CompanyManagement.Infrastructure.Persistence;
using CompanyManagement.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CompanyManagementDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("CompanyManagement")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<CompanyManagementDbContext>();


            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        }
    }
}
