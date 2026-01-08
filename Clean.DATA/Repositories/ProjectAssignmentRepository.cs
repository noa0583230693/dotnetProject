using System.Collections.Generic;
using System.Linq;
using Clean.CORE.Entities;
using Clean.CORE.IRepositories;
using Clean.DATA.Data;

namespace Clean.DATA.Repositories
{
    public class ProjectAssignmentRepository: Repository<ProjectAssignment>,IProjectAssignmentRepository
    {
        private readonly IDataContext _context;

        public ProjectAssignmentRepository(DataContext context):base(context) { }


        public IEnumerable<ProjectAssignment> GetAssignmentsByProject(int projectId)
        {
            return _context.Assignments
                .Where(a => a.ProjectId == projectId);
        }
    }
}
