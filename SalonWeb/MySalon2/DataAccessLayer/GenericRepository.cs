using Microsoft.EntityFrameworkCore;
using SalonWeb.Data;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SalonWeb.DataAccessLayer
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal ApplicationDbContext _context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(ApplicationDbContext _context)
        {
            this._context = _context;
            this.dbSet = _context.Set<TEntity>();
        }

        public void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void Update(TEntity entityToUpdate)
        {
            try
            {
                TEntity local = _context.Set<TEntity>().Local.FirstOrDefault();
                if (local != null)
                {
                    _context.Entry(local).State = EntityState.Detached;
                }
                _context.Entry(entityToUpdate).State = EntityState.Modified;
                return;
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public virtual void Delete(int id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual TEntity GetByID(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }      
    }
}
