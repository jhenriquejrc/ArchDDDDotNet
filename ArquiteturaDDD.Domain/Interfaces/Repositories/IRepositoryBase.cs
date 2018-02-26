using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ArquiteturaDDD.Domain.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        int Save(TEntity obj);
        int Update(TEntity obj);
        void Delete(TEntity obj);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(object id);
        IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> expression);
        IEnumerable<TEntity> OrderBy(Expression<System.Func<TEntity, bool>> expression);
        void Dispose();
    }
}
