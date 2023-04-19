using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Project.Commands.EditProject
{
	public class EditProjectCommandValidator : AbstractValidator<EditProjectCommand>
	{
		public EditProjectCommandValidator()
		{
			RuleFor(c => c.Description)
				.MinimumLength(2)
				.MaximumLength(50);
		}
	}
}
