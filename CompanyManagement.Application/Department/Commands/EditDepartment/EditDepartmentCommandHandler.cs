using CompanyManagement.Application.ApplicationUser;
using CompanyManagement.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Department.Commands.EditDepartment
{
    internal class EditDepartmentCommandHandler : IRequestHandler<EditDepartmentCommand>
    {
        private readonly IDepartmentRepository _repository;
        private readonly IUserContext _userContext;

        public EditDepartmentCommandHandler(IDepartmentRepository repository, IUserContext userContext)
        {
            _repository = repository;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(EditDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = await _repository.GetById(request.Id!);

            var user = _userContext.GetCurrentUser();
            var isEditable = user != null && department.CreatedById == user.Id || user.IsInRole("Moderator");


            if (!isEditable)
            {
                return Unit.Value;
            }

            
            department.Description = request.Description;

            await _repository.Commit();

            return Unit.Value;
        }
    }
}
