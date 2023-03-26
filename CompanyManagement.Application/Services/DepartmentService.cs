using AutoMapper;
using CompanyManagement.Application.Department;
using CompanyManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }
        public async Task Create(DepartmentDto departmentDto)
        {
            var department = _mapper.Map<Domain.Entities.Department>(departmentDto);

            await _departmentRepository.Create(department);
        }
    }
}
