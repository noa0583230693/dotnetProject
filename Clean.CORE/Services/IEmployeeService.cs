using Clean.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.CORE.Services
{
    public interface IEmployeeService
    {
        public IEnumerable<Employee> GetAll();

        public Employee? GetById(int id);

        public Employee Add(Employee employee);

        public Employee? Update(int id, Employee updated);

        public bool Delete(int id);

        public IEnumerable<Employee> GetByRole(string role);
    }
}
