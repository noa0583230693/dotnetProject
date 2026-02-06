using Clean.CORE.Entities;
using Clean.CORE.IRepositories;
using Clean.DATA.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clean.DATA.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IemployeeRepository
    {
        private readonly IDataContext _context;

        public EmployeeRepository(DataContext context) : base(context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Employee>> GetByRoleAsync(string role)
        {
            if (string.IsNullOrWhiteSpace(role))
                return Enumerable.Empty<Employee>();

            var normalized = role.ToLowerInvariant();

            var employees = await _context.Employees
                .Where(e => e.Role != null && e.Role.ToLower() == normalized)
                .ToListAsync();

            return employees;
        }

        public Task<Employee?> GetEmployeeWithAssignmentsAsync(int id)
        {
            return _context.Employees
                                      .Include(e => e.Assignments)
                                      .ThenInclude(a => a.Project)
                                      .FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task AddAssignmentAsync(int employeeId, int projectId, string roleInProject)
        {
            var assignment = new ProjectAssignment
            {
                EmployeeId = employeeId,
                ProjectId = projectId,
                EmployeeRoleInProject = roleInProject
            };

            _context.Assignments.Add(assignment);
            await _context.SaveChangesAsync();
        }

    }
}
