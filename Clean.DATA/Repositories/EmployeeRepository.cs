using System;
using System.Collections.Generic;
using System.Linq;
using Clean.CORE.Entities;
using Clean.CORE.IRepositories;
using Clean.DATA.Data;

namespace Clean.DATA.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IemployeeRepository
    {
        private readonly IDataContext _context;

        public EmployeeRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetByRole(string role)
        {
            return _context.Employees
                .Where(e => e.Role.Equals(role, StringComparison.OrdinalIgnoreCase));
        }

       
    }
}
