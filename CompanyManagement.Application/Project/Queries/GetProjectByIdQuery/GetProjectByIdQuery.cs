using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Project.Queries.GetProjectByIdQuery
{
    public class GetProjectByIdQuery : IRequest<ProjectDto>
    {
        public int Id { get; set; }

        public GetProjectByIdQuery(int projectId)
        {
            Id = projectId;
        }
    }
}
