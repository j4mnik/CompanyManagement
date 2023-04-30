using AutoMapper;
using CompanyManagement.Application.Employee;
using CompanyManagement.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Department.Queries.GetDepartmentByIdQuery
{
    internal class GetDepartmentByIdQueryHandler : IRequestHandler<GetDepartmentByIdQuery, DepartmentDto>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public GetDepartmentByIdQueryHandler(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<DepartmentDto> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var department = await _departmentRepository.GetById(request.Id);

			var departmentDto = _mapper.Map<DepartmentDto>(department);

			var employees = department.Employees.Select(e => _mapper.Map<EmployeeDto>(e)).ToList();
			departmentDto.Employees = employees;

			var dto = _mapper.Map<DepartmentDto>(department);

            return dto;
        }
    }
}
