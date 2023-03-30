using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Application.Department.Queries.GetDepartmentByIdQuery
{
    public class GetDepartmentByIdQuery : IRequest<DepartmentDto>
    {
        public int Id { get; set; }

        public GetDepartmentByIdQuery(int departmentId)
        {
            Id = departmentId; 
        }
    }
}
