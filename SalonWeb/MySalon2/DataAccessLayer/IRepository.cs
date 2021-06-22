using System;
using System.Linq;
using System.Linq.Expressions;

namespace SalonWeb.DataAccessLayer
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Insert(TEntity entity);
        void Update(TEntity entityToUpdate);
        void Delete(TEntity entityToDelete);
        void Delete(int id);
        TEntity GetByID(int id);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        
    }
}
