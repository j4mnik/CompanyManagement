using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Project.Queries.GetProject
{
    public class GetAllProjectsQuery : IRequest<IEnumerable<ProjectDto>>
    {
        public int Id { get; set; } = default!;
    }
}
