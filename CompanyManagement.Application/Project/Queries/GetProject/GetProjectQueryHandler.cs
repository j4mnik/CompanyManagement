using AutoMapper;
using CompanyManagement.Domain.Interfaces;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Project.Queries.GetProject
{
    public class GetProjectQueryHandler : IRequestHandler<GetProjectQuery, IEnumerable<ProjectDto>>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public GetProjectQueryHandler(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProjectDto>> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {
            var result = await _projectRepository.GetAllById(request.Id);

            var dtos = _mapper.Map<IEnumerable<ProjectDto>>(result);

            return dtos;
        }
    }
}
