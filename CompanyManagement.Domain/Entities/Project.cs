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

        public int DepartmentId { get; set; } = default!;
        public Department Department { get; set; } = default!;

    }
    public enum ProjectStatus
    {
        NotStarted,
        InProgress,
        Completed
    }
}
