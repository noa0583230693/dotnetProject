using System;
using System.Collections.Generic;
using System.Text;

namespace Clean.CORE.Repositories
{
   
        public interface IRepository<T> where T : class
        {
            IEnumerable<T> GetAll();
            T? GetById(int id);
            T Add(T entity);
            T Update(int id,T entity); // או void, תלוי איך מימשת עד עכשיו
            bool Delete(int id);
        }
    }
