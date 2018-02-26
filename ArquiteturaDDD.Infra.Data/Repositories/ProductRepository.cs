using System;
using System.Collections.Generic;
using ArquiteturaDDD.Domain.Entities;
using ArquiteturaDDD.Domain.Interfaces;
using ArquiteturaDDD.Infra.Data.Context;

namespace ArquiteturaDDD.Infra.Data.Repositories
{
    public class ProductRepository : ArquiteturaDDDContext<Product>, IProductRepository
    {
        public IEnumerable<Product> SearchForDescription(string description)
        {
            return Where(p => p.Description == description);
        }
    }
}
