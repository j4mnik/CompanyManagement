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
        [Required]
        [StringLength(20, MinimumLength =2)]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string? Description { get; set; }
    }
}
