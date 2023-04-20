using CompanyManagement.Application.ApplicationUser;
using CompanyManagement.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.ProjectTask.Commands.EditProjectTask
{
	public class EditProjectTaskCommandHandler : IRequestHandler<EditProjectTaskCommand> 
	{
		private readonly IProjectTaskRepository _repository;
		private readonly IUserContext _userContext;

		public EditProjectTaskCommandHandler(IProjectTaskRepository repository, IUserContext userContext)
		{
			_repository = repository;
			_userContext = userContext;
		}

		public async Task<Unit> Handle(EditProjectTaskCommand request, CancellationToken cancellationToken)
		{
			var projectTask = await _repository.GetById(request.Id!);
			var user = _userContext.GetCurrentUser();
			var isEditable = user != null && (projectTask.CreatedById == user.Id || user.IsInRole("Admin"));

			if (!isEditable)
			{
				return Unit.Value;
			}

			projectTask.Name = request.Name;
			projectTask.Description = request.Description;
			projectTask.Status = (Domain.Entities.ProjectTask.ProjectTaskStatus)request.Status;

			await _repository.Commit();

			return Unit.Value;

		}
	}
}
