using System.Collections.Generic;
using System.Linq;
using Clean.CORE.Entities;
using Clean.CORE.IRepositories;
using Clean.DATA.Data;

namespace Clean.DATA.Repositories
{
    public class ProjectRepository:Repository<Project>, IProjectRepository
    {
        private readonly IDataContext _context;

        public ProjectRepository(DataContext context): base(context) {}



        public IEnumerable<Project> SearchProject(string keyword)
        {
            return _context.Projects
                .Where(p => p.Name.Contains(keyword, System.StringComparison.OrdinalIgnoreCase));
        }
    }
}
