using CompanyManagement.Application.Department;
using CompanyManagement.Domain.Entities;

namespace CompanyManagement.Application.Services
{
    public interface IDepartmentService
    {
        Task Create(DepartmentDto department);

        Task<IEnumerable<DepartmentDto>> GetAll();
    }
}