using System.Collections.Generic;
using Clean.DATA.Repositories;
using Clean.CORE.Entities;
using Clean.CORE.IRepositories;
using Clean.CORE.Services;
using Clean.CORE.Repositories;

namespace Clean.SERVICE
{
    public class ProjectAssignmentService:IProjectAssignmentService
    {
        private readonly IRepositoryManager _repositoryManager;

        public ProjectAssignmentService(IRepositoryManager repository)
        {
            _repositoryManager = repository;
        }

        public IEnumerable<ProjectAssignment> GetAll() => _repositoryManager.ProjectAssignments.GetAll();

        public ProjectAssignment? GetById(int id) => _repositoryManager.ProjectAssignments.GetById(id);

        public ProjectAssignment Add(ProjectAssignment assignment)
        {
            // 1. הוספה לזיכרון (ה-Repo מוסיף ל-DbSet)
            var newAssignment = _repositoryManager.ProjectAssignments.Add(assignment);

            // 2. שמירה פיזית לדאטה בייס (Commit)
            _repositoryManager.Save();

            return newAssignment;
        }

        public ProjectAssignment? Update(int id, ProjectAssignment updated)
        {

            var tmp=_repositoryManager.ProjectAssignments.Update(id, updated);
            _repositoryManager.Save();
            return tmp;
        }

        public bool Delete(int id)
        {
            var isDeleted = _repositoryManager.ProjectAssignments.Delete(id);
            if (isDeleted)
            {
                // שמירה רק אם המחיקה הצליחה לוגית
                _repositoryManager.Save();
            }
            return isDeleted;

        }

        public IEnumerable<ProjectAssignment> GetByProject(int projectId) => _repositoryManager.ProjectAssignments.GetAssignmentsByProject(projectId);
    }
}
