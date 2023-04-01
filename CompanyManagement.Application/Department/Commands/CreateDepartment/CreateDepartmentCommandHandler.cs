using AutoMapper;
using CompanyManagement.Application.ApplicationUser;
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
        private readonly IUserContext _userContext;

        public CreateDepartmentCommandHandler(IDepartmentRepository departmentRepository, IMapper mapper, IUserContext userContext)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _userContext.GetCurrentUser();
            if(currentUser == null || !currentUser.IsInRole("Owner"))
            {
                return Unit.Value;
            }

            var department = _mapper.Map<Domain.Entities.Department>(request);

            department.CreatedById = currentUser.Id;

            await _departmentRepository.Create(department);

            return Unit.Value;
        }
    }
}
