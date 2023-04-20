using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.ProjectTask.Queries.GetProjectTasks
{
    public class GetProjectTaskQuery : IRequest<IEnumerable<ProjectTaskDto>>
    {
        public int Id { get; set; } = default!;

    }
}
