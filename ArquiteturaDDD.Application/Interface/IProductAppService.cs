using ArquiteturaDDD.Domain.Entities;
using System.Collections.Generic;

namespace ArquiteturaDDD.Application.Interface
{
    public interface IProductAppService : IAppServiceBase<Product>
    {
        IEnumerable<Product> SearchByDescription(string description);
    }
}
