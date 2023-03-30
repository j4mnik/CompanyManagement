using CompanyManagement.Application.Department;
using CompanyManagement.Application.Department.Commands.CreateDeprartment;
using CompanyManagement.Application.Department.Queries.GetAllDepartments;
using CompanyManagement.Application.Department.Queries.GetDepartmentByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManagement.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IMediator _mediator;

        public DepartmentController(IMediator mediator) 
        {
            _mediator = mediator;         } 

        public async Task<IActionResult> Index() 
        {
            var departments = await _mediator.Send(new GetAllDepartmentsQuery());
            return View(departments); 
        }

        public IActionResult Create()
        {
            return View();
        }

        [Route("Department/{Id}/Details")]
        public async Task<IActionResult> Details(int Id)
        {
            var dto = await _mediator.Send(new GetDepartmentByIdQuery(Id));
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDepartmentCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
}
