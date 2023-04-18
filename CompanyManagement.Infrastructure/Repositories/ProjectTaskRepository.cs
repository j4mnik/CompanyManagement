using CompanyManagement.Domain.Entities;
using CompanyManagement.Domain.Interfaces;
using CompanyManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Infrastructure.Repositories
{
    public class ProjectTaskRepository : IProjectTaskRepository
    {
        private readonly CompanyManagementDbContext _dbContext;

        public ProjectTaskRepository(CompanyManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(ProjectTask projectTask)
        {
            _dbContext.Tasks.Add(projectTask);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProjectTask>> GetAllById(int id)
            => await _dbContext.Tasks
             .Where(p => p.Project.Id == id)
             .ToListAsync();

    }
}
