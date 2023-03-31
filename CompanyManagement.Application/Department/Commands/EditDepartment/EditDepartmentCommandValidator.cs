using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Department.Commands.EditDepartment
{
    public class EditDepartmentCommandValidator : AbstractValidator<EditDepartmentCommand>
    {
        public EditDepartmentCommandValidator() 
        {
            RuleFor(c => c.Description)
                .MinimumLength(2)
                .MaximumLength(50);
        }
    }
}
