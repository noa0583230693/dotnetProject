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


     
        public async Task<IEnumerable<Project>> SearchProjectAsync(string keyword)
        {
            return await _context.Projects
                .Where(p => p.Name.Contains(keyword, System.StringComparison.OrdinalIgnoreCase))
                .ToListAsync();
        }

        public async Task<IEnumerable<Project>> GetAllWithAssignmentsAsync()
        {
            return await _context.Projects
              .Include(p =>  p.Assignments)
              .ThenInclude(a => a.Employee)
              .ToListAsync();
        }


        public async Task<Project?> GetByIdWithAssignmentsAsync(int id)
        {
            return await _context.Projects
                     .Include(p => p.Assignments)
                     .ThenInclude(a => a.Employee)
                     .FirstOrDefaultAsync(p => p.Id == id);
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
