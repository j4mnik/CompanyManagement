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

        public EditDepartmentCommandHandler(IDepartmentRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(EditDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = await _repository.GetById(request.Id!);
            
            department.Description = request.Description;

            await _repository.Commit();

            return Unit.Value;
        }
    }
}
