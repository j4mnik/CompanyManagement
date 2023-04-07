using AutoMapper;
using CompanyManagement.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Project.Queries.GetProjectByIdQuery
{
	internal class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ProjectDto>
	{
		private readonly IProjectRepository _projectRepository;
		private readonly IMapper _mapper;

		public GetProjectByIdQueryHandler(IProjectRepository projectRepository, IMapper mapper)
		{
			_projectRepository = projectRepository;
			_mapper = mapper;

		}

		public async Task<ProjectDto> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
		{
			var project = await _projectRepository.GetById(request.Id);

			var dto = _mapper.Map<ProjectDto>(project);

			return dto;
		}
	}
}
