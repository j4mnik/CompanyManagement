using AutoMapper;
using CompanyManagement.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Department.Commands.CreateDeprartment
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public CreateDepartmentCommandHandler(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = _mapper.Map<Domain.Entities.Department>(request);

            await _departmentRepository.Create(department);
           
            return Unit.Value;
        }
    }
}
