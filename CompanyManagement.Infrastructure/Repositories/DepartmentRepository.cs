using CompanyManagement.Domain.Entities;
using CompanyManagement.Domain.Interfaces;
using CompanyManagement.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Infrastructure.Repositories
{
    internal class DepartmentRepository : IDepartmentRepository
    {
        private CompanyManagementDbContext _dbContext;

        public DepartmentRepository(CompanyManagementDbContext dbContext)
        { 
            _dbContext = dbContext;
        }

        public async Task Create(Department department)
        {
            _dbContext.Add(department);
            await _dbContext.SaveChangesAsync();
        }
    }
}
