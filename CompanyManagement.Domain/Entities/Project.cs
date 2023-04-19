using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Domain.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public ProjectStatus Status { get; set; } = default!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Budget { get; set; }
        public decimal ActualCost { get; set; }
		public string? CreatedById { get; set; }
		public IdentityUser? CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
		public int DepartmentId { get; set; } = default!;
        public Department Department { get; set; } = default!;

        public List<ProjectTask> Tasks { get; set; } = new();

    }
    public enum ProjectStatus
    {
        NotStarted,
        InProgress,
        Completed
    }
}
