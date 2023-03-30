using CompanyManagement.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Department.Commands.CreateDeprartment
{
    public class CreateDepartmentCommandValidator : AbstractValidator<CreateDepartmentCommand>
    {
        public CreateDepartmentCommandValidator(IDepartmentRepository repository)
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(20)
                .Custom((value, context) =>
                {
                    var exisitingDepartment = repository.GetByName(value).Result;

                    if (exisitingDepartment != null)
                    {
                        context.AddFailure($"{value} is not unique for department");
                    }
                });

            RuleFor(c => c.Description)
                .MinimumLength(2)
                .MaximumLength(50);
        }
    }
}
