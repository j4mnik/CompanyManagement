using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CompanyManagement.Application.Employee;
using CompanyManagement.Application.Services;
using CompanyManagement.Application.Department.Queries.GetAllDepartments;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CompanyManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMediator _mediator;

        public EmployeeController(IEmployeeService employeeService, IMediator mediator)
        {
            _employeeService = employeeService;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var employee = await _employeeService.GetAllEmployees();
            return View(employee);
        }


        [Authorize(Roles = "DepartmentManager, Admin")]
        public async Task<IActionResult> Create()
        {
            var departments = await _mediator.Send(new GetAllDepartmentsQuery());
            ViewBag.Departments = departments;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeDto employee)
        {
            await _employeeService.Create(employee);
            return RedirectToAction(nameof(Create));
        }
    }
}
