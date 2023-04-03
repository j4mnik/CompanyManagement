using MediatR;

namespace CompanyManagement.Application.Project.Commands
{
	public class CreateProjectCommand : ProjectDto, IRequest
	{
        public int Id { get; set; } = default!;

    }
}
