using Clean.CORE.DTO;
using Clean.CORE.Entities;
using Clean.CORE.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.CORE.IRepositories
{
    public interface IProjectAssignmentRepository: IRepository<ProjectAssignment>
    {
        public Task<IEnumerable<ProjectAssignment>> GetAssignmentsByProjectAsync(int projectId);
        public Task<IEnumerable<ProjectAssignment>> GetAssignmentsByEmployeeAsync(int employeeId);



    }
}
