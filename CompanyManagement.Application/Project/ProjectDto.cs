using CompanyManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Project
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public ProjectStatus Status { get; set; } = default!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Budget { get; set; }
        public decimal ActualCost { get; set; }
		public bool IsEditable { get; set; }
		public string? CreatedById { get; set; }
		public int DepartmentId { get; set; } = default!;
    }

    public enum ProjectStatus
    {
        NotStarted,
        InProgress,
        Completed
    }

}
