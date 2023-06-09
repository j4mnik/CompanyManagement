﻿using CompanyManagement.Application.Employee;
using CompanyManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Department
{
    public class DepartmentDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = default!;

        public string? Description { get; set; }

        public bool IsEditable { get; set; }

		public List<EmployeeDto> Employees { get; set; } = new List<EmployeeDto>();
	}
}
