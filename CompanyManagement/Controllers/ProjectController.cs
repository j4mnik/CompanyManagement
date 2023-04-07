using AutoMapper;
using CompanyManagement.Application.Project.Commands;
using CompanyManagement.Application.Project.Queries.GetProject;
using CompanyManagement.Application.Project.Queries.GetProjectByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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
    }

}
