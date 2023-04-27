using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Domain.Entities
{
    public class Employee 
    {
        public int Id { get; set; }   
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public int? DepartmentId { get; set; } 
        public Department? Department { get; set; }
        public virtual ICollection<ProjectTask> Tasks { get; set; }
    }
}