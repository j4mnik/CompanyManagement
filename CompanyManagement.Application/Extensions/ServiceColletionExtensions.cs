using CompanyManagement.Application.Department;
using CompanyManagement.Application.Mappings;
using CompanyManagement.Application.Services;
using CompanyManagement.Domain.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Extensions
{
    public static class ServiceColletionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentService, DepartmentService>();

            services.AddAutoMapper(typeof(DepartmentMappingProfile));

            services.AddValidatorsFromAssemblyContaining<DepartmentDtoValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

        }
    }
}
