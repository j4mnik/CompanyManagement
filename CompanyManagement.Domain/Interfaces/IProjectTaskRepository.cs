using CompanyManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Domain.Interfaces
{
    public interface IProjectTaskRepository
    {
        Task Create(ProjectTask projectTask);

        Task<IEnumerable<ProjectTask>> GetAllById(int id);
    }
}
