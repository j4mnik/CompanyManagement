using CompanyManagement.Application.ApplicationUser;
using CompanyManagement.Domain.Entities;
using CompanyManagement.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Project.Commands
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand>
    {
        private readonly IUserContext _userContext;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IProjectRepository _projectRepository;

        public CreateProjectCommandHandler(IUserContext userContext, IDepartmentRepository departmentRepository, 
            IProjectRepository projectRepository)
        { 
            _userContext = userContext;
            _departmentRepository = departmentRepository;
            _projectRepository = projectRepository;
        }

        public async Task<Unit> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var department = await _departmentRepository.GetById(request.DepartmentId);

            if (department == null)
            {
                // The department with the specified ID does not exist
                throw new ArgumentException($"Department with ID {request.DepartmentId} does not exist.");
            }

            var user = _userContext.GetCurrentUser();
            var isEditable = user != null && (department.CreatedById == user.Id || user.IsInRole("Moderator"));

            if (!isEditable)
            {
                return Unit.Value;
            }

            var project = new Domain.Entities.Project()
            {
                Name = request.Name,
                Description = request.Description,
                Status = (Domain.Entities.ProjectStatus)request.Status,
                DepartmentId = department.Id,
            };

            await _projectRepository.Create(project);

            return Unit.Value;
        }
    }
}
