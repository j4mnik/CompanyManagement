using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Domain.Entities
{
    public class ProjectTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
		public ProjectTaskStatus Status { get; set; } = default!;
		public int ProjectId { get; set; } = default!;
        public Project Project { get; set; } = default!;

		public enum ProjectTaskStatus
		{
			InProgress,
			Completed
		}
	}
}
