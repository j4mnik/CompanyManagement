using CompanyManagement.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Project.Commands
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {

        public CreateProjectCommandValidator() {
            RuleFor(s => s.Name).NotEmpty();
            RuleFor(s => s.Description).NotEmpty();
        }
    }
}
