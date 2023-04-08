using AutoMapper;
using CompanyManagement.Application.Department;
using CompanyManagement.Application.Department.Commands.CreateDeprartment;
using CompanyManagement.Application.Department.Commands.EditDepartment;
using CompanyManagement.Application.Department.Queries.GetAllDepartments;
using CompanyManagement.Application.Department.Queries.GetDepartmentByIdQuery;
using CompanyManagement.Application.Project.Commands;
using CompanyManagement.Application.Project.Queries.GetProject;
using CompanyManagement.Extensions;
using CompanyManagement.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CompanyManagement.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public DepartmentController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var departments = await _mediator.Send(new GetAllDepartmentsQuery());
            return View(departments);
        }


        [Authorize(Roles = "DepartmentManager, Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateDepartmentCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);

            this.SetNotification("success", $"Created department: {command.Name}");

            return RedirectToAction(nameof(Index));
        }


        [Route("Department/{Id}/Details")]
        public async Task<IActionResult> Details(int Id)
        {
            var dto = await _mediator.Send(new GetDepartmentByIdQuery(Id));
            return View(dto);
        }

        [Route("Department/{Id}/Edit")]
        public async Task<IActionResult> Edit(int Id)
        {
            var dto = await _mediator.Send(new GetDepartmentByIdQuery(Id));

            if (!dto.IsEditable)
            {
                return RedirectToAction("NoAccess", "Home");
            }


            EditDepartmentCommand model = _mapper.Map<EditDepartmentCommand>(dto);

            return View(model);
        }


        [HttpPost]
        [Route("Department/{Id}/Edit")]
        public async Task<IActionResult> Edit(int Id, EditDepartmentCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

		[HttpPost]
        [Authorize(Roles = "DepartmentManager, Admin")]
        [Route("Department/Project")]
		public async Task<IActionResult> CreateProject(CreateProjectCommand command)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);

            }
            await _mediator.Send(command);

            return Ok();
        }

        [HttpGet]
        [Route("Department/{Id}/Project")]
        public async Task<IActionResult> GetProjects(int id)
        {
            var data = await _mediator.Send(new GetProjectQuery() { Id = id });
            return Ok(data);
        }
    }
}