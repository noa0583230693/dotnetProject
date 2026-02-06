using Clean.CORE.Entities;
using Clean.CORE.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.CORE.Services
{
    public interface IEmployeeService
    {
        public Task<IEnumerable<EmployeeDto>> GetAllAsync();

        public Task<EmployeeDto?> GetByIdAsync(int id);

        public Task<EmployeeDto> AddAsync(Employee employee);

        public Task<EmployeeDto?> UpdateAsync(int id, Employee updated);

        public Task<bool> DeleteAsync(int id);

        public Task<IEnumerable<EmployeeDto>> GetByRoleAsync(string role);

        public Task<EmployeeWithAssignmentsDto?> GetEmployeeWithAssignmentsAsync(int id);


        //special
       public Task<IEnumerable<RecommendedEmployeeDto>> GetRecommendedEmployeesAsync(int projectId,string requiredRole);

    }
}
