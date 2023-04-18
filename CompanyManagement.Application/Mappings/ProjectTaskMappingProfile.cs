using AutoMapper;
using CompanyManagement.Application.Project;
using CompanyManagement.Application.ProjectTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Mappings
{
    public class ProjectTaskMappingProfile : Profile 
    {
        public ProjectTaskMappingProfile()
        {
            CreateMap<ProjectTaskDto, Domain.Entities.ProjectTask>()
             .ReverseMap();

    
        }
    }
}
