using Clean.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.CORE.Services
{
    public interface IProjectAssignmentService
    {


        public IEnumerable<ProjectAssignment> GetAll();

        public ProjectAssignment? GetById(int id);

        public ProjectAssignment Add(ProjectAssignment assignment);

        public ProjectAssignment? Update(int id, ProjectAssignment updated);

        public bool Delete(int id);

        public IEnumerable<ProjectAssignment> GetByProject(int projectId);
    }
}
