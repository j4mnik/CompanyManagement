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
    public class ProjectRepository : IProjectRepository
    {
        private readonly CompanyManagementDbContext _dbContext;

        public ProjectRepository(CompanyManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Project project)
        {
            _dbContext.Projects.Add(project);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Project>> GetAllById(int id)
         => await _dbContext.Projects
             .Where(p => p.Department.Id == id)
             .ToListAsync();
    }
}
