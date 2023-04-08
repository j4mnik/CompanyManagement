using AutoMapper;
using CompanyManagement.Application.Project;
using CompanyManagement.Application.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Mappings
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<EmployeeDto, Domain.Entities.Employee>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate));
            CreateMap<Domain.Entities.Employee, EmployeeDto>();
        }
    }
}