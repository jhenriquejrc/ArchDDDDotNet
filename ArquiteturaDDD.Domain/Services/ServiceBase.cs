using ArquiteturaDDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using ArquiteturaDDD.Domain.Interfaces;

namespace ArquiteturaDDD.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }
        public void Delete(TEntity obj)
        {
            _repository.Delete(obj);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity GetById(object id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<TEntity> OrderBy(Expression<Func<TEntity, bool>> expression)
        {
            return _repository.OrderBy(expression);
        }

        public int Save(TEntity obj)
        {
           return _repository.Save(obj);
        }

        public int Update(TEntity obj)
        {
            return _repository.Update(obj);
        }

        public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
        {
            return _repository.Where(expression);
        }
    }
}
