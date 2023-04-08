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
    internal class DepartmentRepository : IDepartmentRepository
    {
        private CompanyManagementDbContext _dbContext;

        public DepartmentRepository(CompanyManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Commit()
            => _dbContext.SaveChangesAsync();

        public async Task Create(Department department)
        {
            _dbContext.Add(department);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Department>> GetAll()
            => await _dbContext.Departments.ToListAsync();

        public async Task<Department> GetById(int id)
              => await _dbContext.Departments
                        .Include(d => d.Employees)
                        .FirstAsync(c => c.Id == id);

        public Task<Department?> GetByName(string name)
            => _dbContext.Departments.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());

    }
}
