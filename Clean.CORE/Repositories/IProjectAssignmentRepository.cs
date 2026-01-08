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
      
        public IEnumerable<ProjectAssignment> GetAssignmentsByProject(int projectId);
    }
}
