using AutoMapper;
using CompanyManagement.Application.ApplicationUser;
using CompanyManagement.Application.ProjectTask;
using CompanyManagement.Application.ProjectTask.Commands.EditProjectTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Mappings
{
    public class ProjectTaskMappingProfile : Profile
    {
        public ProjectTaskMappingProfile(IUserContext userContext)
        {
			var user = userContext.GetCurrentUser();

			CreateMap<ProjectTaskDto, Domain.Entities.ProjectTask>();

			CreateMap<Domain.Entities.ProjectTask, ProjectTaskDto>()
			 .ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => user != null && (src.CreatedById == user.Id || user.IsInRole("Admin"))));

			CreateMap<ProjectTaskDto, EditProjectTaskCommand>();
            CreateMap<ProjectTaskDto, Domain.Entities.ProjectTask>()
    .           ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId));
            CreateMap<Domain.Entities.ProjectTask, ProjectTaskDto>()
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId));

        }
    }
}
