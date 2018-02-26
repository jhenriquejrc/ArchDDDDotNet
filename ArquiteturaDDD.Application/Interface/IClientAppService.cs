using ArquiteturaDDD.Domain.Entities;
using System.Collections;
using System.Collections.Generic;

namespace ArquiteturaDDD.Application.Interface
{
    public interface IClientAppService : IAppServiceBase<Client>
    {
        IEnumerable<Client> GetSpecialClients();
    }
}
