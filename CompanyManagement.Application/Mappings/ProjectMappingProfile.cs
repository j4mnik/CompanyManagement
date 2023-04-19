using AutoMapper;
using CompanyManagement.Application.ApplicationUser;
using CompanyManagement.Application.Project;
using CompanyManagement.Application.Project.Commands.EditProject;


namespace CompanyManagement.Application.Mappings
{
    public class ProjectMappingProfile : Profile
    {
        public ProjectMappingProfile(IUserContext userContext) 
        {
			var user = userContext.GetCurrentUser();

			CreateMap<ProjectDto, Domain.Entities.Project>();

			CreateMap<Domain.Entities.Project, ProjectDto>()
			 .ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => user != null && (src.CreatedById == user.Id || user.IsInRole("Admin"))));

			CreateMap<ProjectDto, EditProjectCommand>();

		}
    }
}
