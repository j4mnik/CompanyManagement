using AutoMapper;
using CompanyManagement.Application.ApplicationUser;
using CompanyManagement.Application.Department.Commands.CreateDeprartment;
using CompanyManagement.Application.Mappings;
using CompanyManagement.Application.Services;
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
            services.AddAutoMapper(typeof(EmployeeMappingProfile));
            services.AddMediatR(typeof(CreateDepartmentCommand));
            services.AddScoped<IUserContext, UserContext>();
            services.AddScoped<IEmployeeService, EmployeeService>();


            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                var scope = provider.CreateScope();
                var userContext = scope.ServiceProvider.GetRequiredService<IUserContext>();
                cfg.AddProfile(new DepartmentMappingProfile(userContext));
                cfg.AddProfile(new EmployeeMappingProfile());
            }).CreateMapper());

            services.AddValidatorsFromAssemblyContaining<CreateDepartmentCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
