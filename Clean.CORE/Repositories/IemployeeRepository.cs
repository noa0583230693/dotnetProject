using Clean.CORE.Entities;
using Clean.CORE.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.CORE.IRepositories
{
    public interface IemployeeRepository: IRepository<Employee>
    {
        public  Task<IEnumerable<Employee>> GetByRoleAsync(string role);

       
        public Task<Employee?> GetEmployeeWithAssignmentsAsync(int id);

        public Task AddAssignmentAsync(int employeeId, int projectId, string roleInProject);

    }
}
