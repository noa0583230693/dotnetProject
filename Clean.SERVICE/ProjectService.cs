using Clean.CORE.Entities;
using Clean.CORE.IRepositories;
using Clean.CORE.Repositories;
using Clean.CORE.Services;
using System.Collections.Generic;

namespace Clean.SERVICE
{
    public class ProjectService:IProjectService
    {
            // מזריקים את המנהל במקום את הרפוזיטורי הישיר
            private readonly IRepositoryManager _repositoryManager;

            public ProjectService(IRepositoryManager repositoryManager)
            {
                _repositoryManager = repositoryManager;
            }

            // --- פעולות קריאה (ללא Save) ---

            public IEnumerable<Project> GetAll()
            {
                return _repositoryManager.Projects.GetAll();
            }

            public Project? GetById(int id)
            {
                return _repositoryManager.Projects.GetById(id);
            }

            public IEnumerable<Project> Search(string keyword)
            {
                return _repositoryManager.Projects.SearchProject(keyword);
            }

            // --- פעולות כתיבה (עם Save) ---

            public Project Add(Project project)
            {
                // 1. הוספה ל-DbSet (זיכרון)
                var newProject = _repositoryManager.Projects.Add(project);

                // 2. שמירה לדאטה בייס
                _repositoryManager.Save();

                return newProject;
            }

            public Project? Update(int id, Project updated)
            {
                // ביצוע העדכון ברמת הזיכרון
                var proj = _repositoryManager.Projects.Update(id, updated);

                // שמירת השינויים
                _repositoryManager.Save();

                return proj;
            }

            public bool Delete(int id)
            {
                // מחיקה לוגית או סימון למחיקה בזיכרון
                bool isDeleted = _repositoryManager.Projects.Delete(id);

                // אם המחיקה הצליחה (מבחינת מציאת האובייקט), שומרים את השינוי ב-DB
                if (isDeleted)
                {
                    _repositoryManager.Save();
                }

                return isDeleted;
            }
        }
    }

