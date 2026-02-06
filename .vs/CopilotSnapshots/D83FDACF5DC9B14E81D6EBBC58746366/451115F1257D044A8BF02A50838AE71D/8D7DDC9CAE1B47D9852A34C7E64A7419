using Clean.CORE.Repositories;
using Clean.DATA.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clean.DATA.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbSet<T> _dbSet;
        public Repository(DataContext context)
        {
            _dbSet = context.Set<T>();
        }
        public T Add(T entity)
        {
            _dbSet.Add(entity);
            return entity;
        }

        public bool Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity == null)
            {
                return false;
            }
            _dbSet.Remove(entity);
            return true;
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet;
        }


        public T? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public T Update(int id, T entity)
        {
            _dbSet.Update(entity);
            return entity;
        }
    }
}
