using Clean.CORE.Entities;
using Clean.CORE.IRepositories;
using Clean.CORE.Repositories;
using Clean.DATA.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clean.DATA.Repositories
{
   
    public class RepositoryManager : IRepositoryManager
    {
        private readonly DataContext _context;

        public IProjectRepository Projects { get; }

        public IemployeeRepository Employees { get; }

        public IProjectAssignmentRepository ProjectAssignments { get; }



        public RepositoryManager(DataContext context, IProjectRepository projectRepository,
           IemployeeRepository employeeRepository , IProjectAssignmentRepository projectAssignmentRepository)
        {
            _context = context;
            Projects = projectRepository;
            Employees = employeeRepository;
            ProjectAssignments= projectAssignmentRepository;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
