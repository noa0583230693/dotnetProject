using Clean.CORE.Entities;
using Clean.CORE.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.CORE.Services
{
    public interface IProjectService
    {

        public Task<IEnumerable<ProjectDto>> GetAllAsync();

        public Task<ProjectDto?> GetByIdAsync(int id);

        public Task<ProjectDto> AddAsync(Project project);

        public Task<ProjectDto?> UpdateAsync(int id, Project updated);

        public Task<bool> DeleteAsync(int id);

        public Task<IEnumerable<ProjectDto>> SearchAsync(string keyword);
        public Task<ProjectWithAssignmentsDto?> GetByIdWithAssignmentsAsync(int id);
        public Task<IEnumerable<ProjectWithAssignmentsDto>> GetAllWithAssignmentsAsync();
        //special
       public  Task<ProjectStabilityDto> GetProjectStabilityAsync(int projectId);
    }
}
