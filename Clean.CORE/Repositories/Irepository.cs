using System;
using System.Collections.Generic;
using System.Text;

namespace Clean.CORE.Repositories
{
   
        public interface IRepository<T> where T : class
        {
            Task<IEnumerable<T>> GetAllAsync();
            Task<T?> GetByIdAsync(int id);
            Task<T> AddAsync(T entity);
            Task<T> UpdateAsync(int id,T entity); // או void, תלוי איך מימשת עד עכשיו
            Task<bool> DeleteAsync(int id);
        }
    }
