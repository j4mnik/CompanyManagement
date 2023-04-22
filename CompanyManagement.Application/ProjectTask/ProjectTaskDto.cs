using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CompanyManagement.Domain.Entities.ProjectTask;

namespace CompanyManagement.Application.ProjectTask
{
    public class ProjectTaskDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
		public ProjectTaskStatus Status { get; set; } = default!;
		public bool IsEditable { get; set; }
		public int ProjectId { get; set; } = default!;
		public string? CreatedById { get; set; }
        public int? EmployeeId { get; set; }


        public enum ProjectTaskStatus
		{
			InProgress,
			Completed
		}
	}
}
