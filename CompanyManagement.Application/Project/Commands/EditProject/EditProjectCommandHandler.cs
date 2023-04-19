using CompanyManagement.Application.ApplicationUser;
using CompanyManagement.Domain.Entities;
using CompanyManagement.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Project.Commands.EditProject
{
	public class EditProjectCommandHandler : IRequestHandler<EditProjectCommand>
	{
		private readonly IProjectRepository _repository;
		private readonly IUserContext _userContext;

		public EditProjectCommandHandler(IProjectRepository repository, IUserContext userContext) 
		{
			_repository = repository;
			_userContext = userContext;
		
		}

		public async Task<Unit> Handle(EditProjectCommand request, CancellationToken cancellationToken)
		{
			var project = await _repository.GetById(request.Id!);

			var user = _userContext.GetCurrentUser();
			var isEditable = user != null && (project.CreatedById == user.Id || user.IsInRole("Admin"));


			if (!isEditable)
			{
				return Unit.Value;
			}

			project.Name = request.Name;
			project.Description = request.Description;
			project.Status = (Domain.Entities.ProjectStatus)request.Status;
			project.StartDate = request.StartDate;
			project.EndDate = request.EndDate;
			project.Budget = request.Budget;
			project.ActualCost = request.ActualCost;

			await _repository.Commit();

			return Unit.Value;

		}
	}
}
