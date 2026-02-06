using Clean.CORE.Entities;
using Clean.CORE.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.CORE.Services
{
    public interface IProjectAssignmentService
    {

        public Task<IEnumerable<ProjectAssignmentDto>> GetAllAsync();

        public Task<ProjectAssignmentDto?> GetByIdAsync(int id);

        public Task<ProjectAssignmentDto> AddAsync(ProjectAssignment assignment);

        public Task<ProjectAssignmentDto?> UpdateAsync(int id, ProjectAssignment updated);

        public Task<bool> DeleteAsync(int id);

        public Task<IEnumerable<ProjectAssignmentDto>> GetByProjectAsync(int projectId);

        public Task<IEnumerable<ProjectAssignmentDto>> GetAssignmentsByEmployeeAsync(int employeeId);
        public Task<IEnumerable<ProjectAssignmentDto>> GetAssignmentsByProjectAsync(int projectId);


      
    }
}
