 using AutoMapper;
using CompanyManagement.Application.Department;
using CompanyManagement.Application.Department.Commands.EditDepartment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Mappings
{
    public class DepartmentMappingProfile : Profile
    {
        public DepartmentMappingProfile()
        {
            CreateMap<DepartmentDto, Domain.Entities.Department>();

			CreateMap<Domain.Entities.Department, DepartmentDto>();

            CreateMap<DepartmentDto, EditDepartmentCommand>();

		}
    }
}
