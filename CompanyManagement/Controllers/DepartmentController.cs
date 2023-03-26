﻿using CompanyManagement.Application.Department;
using CompanyManagement.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManagement.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService) 
        {
            _departmentService = departmentService;
        } 

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DepartmentDto department)
        {
            await _departmentService.Create(department);
            return RedirectToAction(nameof(Create));
        }
    }
}