using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Domain.Interfaces
{
    public interface IDepartmentRepository
    {
        Task Create(Domain.Entities.Department department);
        Task<Domain.Entities.Department?> GetByName(string name);
        Task<IEnumerable<Domain.Entities.Department>> GetAll(); 
        Task<Domain.Entities.Department> GetById(int id);
    }
}
