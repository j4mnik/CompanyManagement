using AutoMapper;
using CompanyManagement.Application.Project.Queries.GetProject;
using CompanyManagement.Application.Project;
using CompanyManagement.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.ProjectTask.Queries.GetProjectTasks
{
    public class GetProjectTaskQueryHandler : IRequestHandler<GetProjectTaskQuery, IEnumerable<ProjectTaskDto>>
    {
        private readonly IProjectTaskRepository _projectTaskRepository;
        private readonly IMapper _mapper;

        public GetProjectTaskQueryHandler(IProjectTaskRepository projectTaskRepository, IMapper mapper)
        {
            _projectTaskRepository = projectTaskRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProjectTaskDto>> Handle(GetProjectTaskQuery request, CancellationToken cancellationToken)
        {
            var result = await _projectTaskRepository.GetAllById(request.Id);

            var dtos = _mapper.Map<IEnumerable<ProjectTaskDto>>(result);

            return dtos;
        }
    }
}
