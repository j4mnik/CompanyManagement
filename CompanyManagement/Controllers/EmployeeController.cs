using CompanyManagement.Application.Employee;
using CompanyManagement.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index()
        {
            var employee = await _employeeService.GetAllEmployees();
            return View(employee);
        }

        public IActionResult Create()
        {
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