using AutoMapper;
using CompanyManagement.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.ProjectTask.Queries.GetProjectTaskByIdQuery
{
	internal class GetProjectTaskByIdQueryHandler : IRequestHandler<GetProjectTaskByIdQuery, ProjectTaskDto>
	{
		private readonly IProjectTaskRepository _projectTaskRepository;
		private readonly IMapper _mapper;


		public GetProjectTaskByIdQueryHandler(IProjectTaskRepository projectTaskRepository, IMapper mapper)
		{
			_projectTaskRepository = projectTaskRepository;
			_mapper = mapper;
		}

		public async Task<ProjectTaskDto> Handle(GetProjectTaskByIdQuery request, CancellationToken cancellationToken)
		{
			var projectTask = await _projectTaskRepository.GetById(request.Id);

			var dto = _mapper.Map<ProjectTaskDto>(projectTask);

			return dto;
		}
	}
}
