using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Department.Commands.CreateDeprartment
{
    public class CreateDepartmentCommand : DepartmentDto, IRequest
    {
    }
}
