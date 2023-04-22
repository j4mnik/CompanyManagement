using CompanyManagement.Application.ApplicationUser;
using CompanyManagement.Domain.Entities;
using CompanyManagement.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.ProjectTask.Commands
{
    public class CreateProjectTaskCommandHandler : IRequestHandler<CreateProjectTaskCommand>
    {
        private readonly IUserContext _userContext;
        private readonly IProjectRepository _projectReposiotry;
        private readonly IProjectTaskRepository _projectTaskRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public CreateProjectTaskCommandHandler(IUserContext userContext, IProjectRepository projectRepository, IProjectTaskRepository projectTaskRepository, IEmployeeRepository employeeRepository)
        {
            _userContext = userContext;
            _projectReposiotry = projectRepository;
            _projectTaskRepository = projectTaskRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<Unit> Handle(CreateProjectTaskCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectReposiotry.GetById(request.Id!);


            var employee = await _employeeRepository.GetById((int)request.EmployeeId);



            var projectTask = new Domain.Entities.ProjectTask()
            {
                Name = request.Name,
                Description = request.Description,
                Status = (Domain.Entities.ProjectTask.ProjectTaskStatus)request.Status,
                ProjectId = project.Id,
                Employee = employee
        };
           


            await _projectTaskRepository.Create(projectTask);

            return Unit.Value;
        }
    }
}
