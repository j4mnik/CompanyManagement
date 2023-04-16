using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.ProjectTask.Commands
{
    public class CreateProjectTaskCommandValidator : AbstractValidator<CreateProjectTaskCommand>
    {
        public CreateProjectTaskCommandValidator()
        {
            RuleFor(s => s.Name).NotEmpty();
            RuleFor(s => s.Description).NotEmpty();
            RuleFor(s => s.Id).NotEmpty().NotNull();
        }
    }
}
