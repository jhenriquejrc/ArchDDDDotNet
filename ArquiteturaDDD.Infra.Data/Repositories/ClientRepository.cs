using ArquiteturaDDD.Domain.Entities;
using ArquiteturaDDD.Domain.Interfaces;
using ArquiteturaDDD.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaDDD.Infra.Data.Repositories
{
    public class ClientRepository :ArquiteturaDDDContext<Client>, IClientRepository
    {
    }
}
