using Clean.CORE.Entities;
using Clean.CORE.IRepositories;
using Clean.CORE.Repositories;
using Clean.CORE.Services;
using Clean.DATA.Repositories;
using System.Collections.Generic;

namespace Clean.SERVICE
{
    public class EmployeeService :IEmployeeService// מגדירה את הלוגיקה העיסקית עבור עובדים
    {

            // שינוי: אנחנו מזריקים את המנהל ולא את הרפוזיטורי הבודד
            private readonly IRepositoryManager _repositoryManager;

            public EmployeeService(IRepositoryManager repositoryManager)
            {
                _repositoryManager = repositoryManager;
            }

            public IEnumerable<Employee> GetAll()
            {
                // גישה דרך המנהל -> לרפוזיטורי של העובדים
                return _repositoryManager.Employees.GetAll();
            }

            public Employee? GetById(int id)
            {
                return _repositoryManager.Employees.GetById(id);
            }

            public Employee Add(Employee employee)
            {
                // 1. הוספה לזיכרון (ה-Repo מוסיף ל-DbSet)
                var newEmployee = _repositoryManager.Employees.Add(employee);

                // 2. שמירה פיזית לדאטה בייס (Commit)
                _repositoryManager.Save();

                return newEmployee;
            }

            public Employee? Update(int id, Employee updated)
            {
                var emp = _repositoryManager.Employees.Update(id, updated);

                // שמירה לאחר העדכון
                _repositoryManager.Save();

                return emp;
            }

            public bool Delete(int id)
            {
                var isDeleted = _repositoryManager.Employees.Delete(id);
                if (isDeleted)
                {
                    // שמירה רק אם המחיקה הצליחה לוגית
                    _repositoryManager.Save();
                }
                return isDeleted;
            }

            public IEnumerable<Employee> GetByRole(string role)
            {
                return _repositoryManager.Employees.GetByRole(role);
            }

     
    }
    
}
