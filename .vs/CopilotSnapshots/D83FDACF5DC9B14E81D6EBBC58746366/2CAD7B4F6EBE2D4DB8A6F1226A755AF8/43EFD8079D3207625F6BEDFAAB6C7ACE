using Clean.CORE.Entities;
using Clean.CORE.IRepositories;
using Clean.DATA.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Clean.DATA.Repositories
{
    public class ProjectRepository:Repository<Project>, IProjectRepository
    {
        private readonly IDataContext _context;

        public ProjectRepository(DataContext context): base(context) {
            _context = context;
        }


        public IEnumerable<Project> SearchProject(string keyword)
        {
            return _context.Projects
                .Where(p => p.Name.Contains(keyword, System.StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Project> GetAllWithAssignments()
        {
            return _context.Projects
              .Include(p =>  p.Assignments)
              .ThenInclude(a => a.Employee)
              .ToList();
        }

        public Project? GetByIdWithAssignments(int id)
        {
            return _context.Projects
                     .Include(p => p.Assignments)
                     .ThenInclude(a => a.Employee)
                     .FirstOrDefault(p => p.Id == id);
        }
        public  async Task<Project?> GetByIdWithDetailsAsync(int id)
        {
            return await _context.Projects
                 .Include(p => p.Assignments)
                    .ThenInclude(a => a.Employee)
                        .ThenInclude(e => e.Assignments)
                 .FirstOrDefaultAsync(p => p.Id == id);
        }

       
    }
}
