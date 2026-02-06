using System.Collections.Generic;
using Clean.DATA.Repositories;
using Clean.CORE.Entities;
using Clean.CORE.IRepositories;
using Clean.CORE.Services;
using Clean.CORE.Repositories;
using AutoMapper;
using Clean.CORE.DTO;

namespace Clean.SERVICE
{
    public class ProjectAssignmentService:IProjectAssignmentService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ProjectAssignmentService(IRepositoryManager repository, IMapper mapper)
        {
            _repositoryManager = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProjectAssignmentDto>> GetAllAsync()
        {
            var list = await _repositoryManager.ProjectAssignments.GetAllAsync();
            return _mapper.Map<IEnumerable<ProjectAssignmentDto>>(list);
        }

        public async Task<ProjectAssignmentDto?> GetByIdAsync(int id)
        {
            var item = await _repositoryManager.ProjectAssignments.GetByIdAsync(id);
            return _mapper.Map<ProjectAssignmentDto>(item);
        }

        public async Task<ProjectAssignmentDto> AddAsync(ProjectAssignment assignment)
        {
            var newAssignment = await _repositoryManager.ProjectAssignments.AddAsync(assignment);
            await _repositoryManager.SaveAsync();
            return _mapper.Map<ProjectAssignmentDto>(newAssignment);
        }

        public async Task<ProjectAssignmentDto?> UpdateAsync(int id, ProjectAssignment updated)
        {
            var tmp = await _repositoryManager.ProjectAssignments.UpdateAsync(id, updated);
            await _repositoryManager.SaveAsync();
            return _mapper.Map<ProjectAssignmentDto>(tmp);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var isDeleted = await _repositoryManager.ProjectAssignments.DeleteAsync(id);
            if (isDeleted) await _repositoryManager.SaveAsync();
            return isDeleted;
        }

        public async Task<IEnumerable<ProjectAssignmentDto>> GetByProjectAsync(int projectId)
        {
            var list = await _repositoryManager.ProjectAssignments.GetAssignmentsByProjectAsync(projectId);
            return _mapper.Map<IEnumerable<ProjectAssignmentDto>>(list);
        }
            

        public async Task<IEnumerable<ProjectAssignmentDto>> GetAssignmentsByEmployeeAsync(int employeeId)
        {
            var list = await _repositoryManager.ProjectAssignments.GetAssignmentsByEmployeeAsync(employeeId);
            return _mapper.Map<IEnumerable<ProjectAssignmentDto>>(list);
      }

        public async Task<IEnumerable<ProjectAssignmentDto>> GetAssignmentsByProjectAsync(int projectId)
        {
            var list = await _repositoryManager.ProjectAssignments.GetAssignmentsByProjectAsync(projectId);
            return _mapper.Map<IEnumerable<ProjectAssignmentDto>>(list);
        }
     
     
    }
}
