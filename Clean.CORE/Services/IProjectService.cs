using Clean.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.CORE.Services
{
    public interface IProjectService
    {

        public IEnumerable<Project> GetAll();

        public Project? GetById(int id);

        public Project Add(Project project);

        public Project? Update(int id, Project updated);

        public bool Delete(int id);

        public IEnumerable<Project> Search(string keyword);
    }
}
