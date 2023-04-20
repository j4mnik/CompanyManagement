using AutoMapper;
using CompanyManagement.Application.Department.Commands.EditDepartment;
using CompanyManagement.Application.Department.Queries.GetDepartmentByIdQuery;
using CompanyManagement.Application.Project.Commands;
using CompanyManagement.Application.Project.Commands.EditProject;
using CompanyManagement.Application.Project.Queries.GetProject;
using CompanyManagement.Application.Project.Queries.GetProjectByIdQuery;
using CompanyManagement.Application.ProjectTask.Commands;
using CompanyManagement.Application.ProjectTask.Commands.EditProjectTask;
using CompanyManagement.Application.ProjectTask.Queries.GetProjectTaskByIdQuery;
using CompanyManagement.Application.ProjectTask.Queries.GetProjectTasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using System.Data;
using System.Security;

namespace CompanyManagement.Controllers
{
	public class ProjectController : Controller
	{

		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public ProjectController(IMediator mediator, IMapper mapper)
		{
			_mediator = mediator;
			_mapper = mapper;
		}


		[Route("Project/{Id}/Details")]
		public async Task<IActionResult> Details(int Id)
		{
			var dto = await _mediator.Send(new GetProjectByIdQuery(Id));
			return View(dto);
		}


		[Route("Project/{Id}/Edit")]
		public async Task<IActionResult> Edit(int Id)
		{
			var dto = await _mediator.Send(new GetProjectByIdQuery(Id));

			if (!dto.IsEditable)
			{
				return RedirectToAction("NoAccess", "Home");
			}

			EditProjectCommand model = _mapper.Map<EditProjectCommand>(dto);

			return View(model);
		}

		[HttpPost]
		[Route("Project/{Id}/Edit")]
		public async Task<IActionResult> Edit(int Id, EditProjectCommand command)
		{
			if (!ModelState.IsValid)
			{
				return View(command);
			}

			await _mediator.Send(command);

			return RedirectToAction("Details", new { Id = command.Id });
		}


		[HttpPost]
        [Authorize(Roles = "Admin")]
		[Route("Project/ProjectTask")]
		public async Task<IActionResult> CreateProjectTask(CreateProjectTaskCommand command)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			await _mediator.Send(command);

			return Ok();
		}

        [HttpGet]
        [Route("Project/{Id}/ProjectTask")]
        public async Task<IActionResult> GetProjectTasks(int id)
        {
            var data = await _mediator.Send(new GetProjectTaskQuery() { Id = id });
            return Ok(data);
        }
    }

}
