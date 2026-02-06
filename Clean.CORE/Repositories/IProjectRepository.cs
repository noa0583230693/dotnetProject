using Clean.CORE.Entities;
using Clean.CORE.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.CORE.IRepositories
{
    public interface IProjectRepository : IRepository<Project>
    {

        public Task<IEnumerable<Project>> SearchProjectAsync(string keyword);

        // מביא את כל הפרויקטים עם כל העובדים
        public Task<IEnumerable<Project>> GetAllWithAssignmentsAsync();

        // מביא פרויקט לפי Id כולל כל העובדים שלו
        public Task<Project?> GetByIdWithAssignmentsAsync(int id);

        //מביא את הפרויקט עם העובדים עם השיוכים של העובדים עבור חישוב ציון לפרויקט
        public Task<Project?> GetByIdWithDetailsAsync(int id);

    }
}
