using AutoMapper;
using CompanyManagement.Application.ProjectTask.Commands.EditProjectTask;
using CompanyManagement.Application.ProjectTask.Queries.GetProjectTaskByIdQuery;
using CompanyManagement.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManagement.Controllers
{
	public class ProjectTaskController : Controller
	{

		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public ProjectTaskController(IMediator mediator, IMapper mapper)
		{
			_mediator = mediator;
			_mapper = mapper;
		}

		[Route("ProjectTask/{Id}/Edit")]
		public async Task<IActionResult> Edit(int Id)
		{
			var dto = await _mediator.Send(new GetProjectTaskByIdQuery(Id));

			if (!dto.IsEditable)
			{
				return RedirectToAction("NoAccess", "Home");
			}

			EditProjectTaskCommand model = _mapper.Map<EditProjectTaskCommand>(dto);

			return View(model);
		}

		[HttpPost]
		[Route("ProjectTask/{Id}/Edit")]
		public async Task<IActionResult> Edit(int Id, EditProjectTaskCommand command)
		{
			if (!ModelState.IsValid)
			{
				return View(command);
			}
            await _mediator.Send(command);

            var projectTask = await _mediator.Send(new GetProjectTaskByIdQuery(Id));
            return RedirectToAction("Details", "Project", new { Id = projectTask.ProjectId });
        }

	}
}
