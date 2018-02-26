using System;
using System.Collections.Generic;
using ArquiteturaDDD.Domain.Entities;
using ArquiteturaDDD.Domain.Interfaces;
using ArquiteturaDDD.Domain.Interfaces.Services;

namespace ArquiteturaDDD.Domain.Services
{
    public class ProductService : ServiceBase<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
            : base(productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> SearchByDescription(string description)
        {
            return _productRepository.SearchForDescription(description);
        }

    }
}
