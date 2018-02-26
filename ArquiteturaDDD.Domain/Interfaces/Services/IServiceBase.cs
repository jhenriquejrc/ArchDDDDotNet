using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaDDD.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
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
