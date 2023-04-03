 using AutoMapper;
using CompanyManagement.Application.ApplicationUser;
using CompanyManagement.Application.Department;
using CompanyManagement.Application.Department.Commands.EditDepartment;
using CompanyManagement.Application.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Mappings
{
    public class DepartmentMappingProfile : Profile
    {
        public DepartmentMappingProfile(IUserContext userContext)
        {
            var user = userContext.GetCurrentUser();

            CreateMap<DepartmentDto, Domain.Entities.Department>();

            CreateMap<Domain.Entities.Department, DepartmentDto>()
                .ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => user != null && (src.CreatedById == user.Id || user.IsInRole("Moderator"))));

            CreateMap<DepartmentDto, EditDepartmentCommand>();

            CreateMap<ProjectDto, Domain.Entities.Project>()
            .ReverseMap();
        }
    }
}
