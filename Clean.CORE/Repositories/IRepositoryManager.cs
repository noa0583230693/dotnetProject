using Clean.CORE.Entities;
using Clean.CORE.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clean.CORE.Repositories
{
    public interface IRepositoryManager
    {
        public IProjectRepository Projects { get; }
        public IemployeeRepository Employees { get; }
        public IProjectAssignmentRepository ProjectAssignments { get; }

        Task SaveAsync();
    }
}
