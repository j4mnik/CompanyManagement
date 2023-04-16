using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.ProjectTask.Commands
{
    public class CreateProjectTaskCommand : ProjectTaskDto, IRequest
    {
        public int Id { get; set; } = default!;



    }
}
