using CompanyManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Domain.Interfaces
{
    public interface IProjectRepository
    {
        Task Create(Project project);

        Task<IEnumerable<Project>> GetAllById(int id);
    }
}
