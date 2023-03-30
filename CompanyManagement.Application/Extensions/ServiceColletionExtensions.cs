using CompanyManagement.Application.Department.Commands.CreateDeprartment;
using CompanyManagement.Application.Mappings;
using CompanyManagement.Domain.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
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
            services.AddMediatR(typeof(CreateDepartmentCommand));

            services.AddAutoMapper(typeof(DepartmentMappingProfile));

            services.AddValidatorsFromAssemblyContaining<CreateDepartmentCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

        }
    }
}
