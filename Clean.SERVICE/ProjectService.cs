using Clean.CORE.Entities;
using Clean.CORE.IRepositories;
using Clean.CORE.Repositories;
using Clean.CORE.Services;
using System.Collections.Generic;
using AutoMapper;
using Clean.CORE.DTO;

namespace Clean.SERVICE
{
    public class ProjectService : IProjectService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ProjectService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProjectDto>> GetAllAsync()
        {
            var list = await _repositoryManager.Projects.GetAllAsync();
            return _mapper.Map<IEnumerable<ProjectDto>>(list);
        }

        public async Task<ProjectDto?> GetByIdAsync(int id)
        {
            var proj = await _repositoryManager.Projects.GetByIdAsync(id);
            return _mapper.Map<ProjectDto>(proj);
        }
       

        public async Task<IEnumerable<ProjectDto>> SearchAsync(string keyword)
        {
            var list = await _repositoryManager.Projects.SearchProjectAsync(keyword);
            return _mapper.Map<IEnumerable<ProjectDto>>(list);
        }

        public async Task<ProjectDto> AddAsync(Project project)
        {
            var newProject = await _repositoryManager.Projects.AddAsync(project);
            await _repositoryManager.SaveAsync();
            return _mapper.Map<ProjectDto>(newProject);
        }

        public async Task<ProjectDto?> UpdateAsync(int id, Project updated)
        {
            var proj = await _repositoryManager.Projects.UpdateAsync(id, updated);
            await _repositoryManager.SaveAsync();
            return _mapper.Map<ProjectDto>(proj);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            bool isDeleted = await _repositoryManager.Projects.DeleteAsync(id);
            if (isDeleted)
            {
                await _repositoryManager.SaveAsync();
            }
            return isDeleted        ;
        }

     

        public async Task<ProjectWithAssignmentsDto?> GetByIdWithAssignmentsAsync(int id)
        {
            var proj = await _repositoryManager.Projects.GetByIdWithAssignmentsAsync(id);
            return _mapper.Map<ProjectWithAssignmentsDto>(proj);
        }

        public async Task<IEnumerable<ProjectWithAssignmentsDto>> GetAllWithAssignmentsAsync()
        {
            var list = await _repositoryManager.Projects.GetAllWithAssignmentsAsync();
            return _mapper.Map<IEnumerable<ProjectWithAssignmentsDto>>(list);
        }

        public async Task<ProjectStabilityDto> GetProjectStabilityAsync(int projectId)
        {
            // שימוש בפונקציית ה-Details שבנינו ב-Repository
            var project = await _repositoryManager.Projects.GetByIdWithDetailsAsync(projectId);

            if (project == null) return null;

            int score = 100;
            var insights = new List<string>();

            // 1. בדיקת גודל צוות
            if (project.Assignments.Count < 2)
            {
                score -= 25;
                insights.Add("צוות מצומצם: הפרויקט תלוי במספר נמוך מאוד של עובדים.");
            }

            // 2. בדיקת עומס צוות (Overload)
            //ממוצע פרויקטים של חבר בצוות
            var avgTeamWorkload = project.Assignments
                .Select(a => a.Employee.Assignments.Count)
                .DefaultIfEmpty(0)
                .Average();

            if (avgTeamWorkload > 3)
            {
                score -= 30;
                insights.Add($"עומס עבודה: חברי הצוות משובצים בממוצע ל-{Math.Round(avgTeamWorkload, 1)} פרויקטים במקביל.");
            }

            // 3. בדיקת ריכוזיות תפקידים (Silo Risk)
            var hasSinglePointsOfFailure = project.Assignments
                .GroupBy(a => a.EmployeeRoleInProject)
                .Any(g => g.Count() == 1);

            if (hasSinglePointsOfFailure && project.Assignments.Count > 1)
            {
                score -= 15;
                insights.Add("סיכון ידע: ישנם תפקידים בפרויקט המאוישים על ידי אדם אחד בלבד.");
            }

            return new ProjectStabilityDto
            {
                ProjectId = projectId,
                ProjectName = project.Name,
                StabilityScore = Math.Max(0, score),
                RiskLevel = score > 75 ? "Low" : score > 45 ? "Medium" : "High",
                Insights = insights
            };
        }
    }
}
   

