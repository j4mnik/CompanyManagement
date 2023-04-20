using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.ProjectTask.Queries.GetProjectTaskByIdQuery
{
	public class GetProjectTaskByIdQuery : IRequest<ProjectTaskDto>
	{
		public int Id { get; set; }

		public GetProjectTaskByIdQuery(int projectTaskId)
		{
			Id = projectTaskId;
		}
	}
}
