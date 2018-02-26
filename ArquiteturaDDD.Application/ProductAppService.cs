

using System;
using System.Collections.Generic;
using ArquiteturaDDD.Application.Interface;
using ArquiteturaDDD.Domain.Entities;
using ArquiteturaDDD.Domain.Interfaces.Services;

namespace ArquiteturaDDD.Application
{
    public class ProductAppService : AppServiceBase<Product>, IProductAppService
    {
        private readonly IProductService _productService;
        public ProductAppService(IProductService productService) 
            : base(productService)
        {
            _productService = productService;
        }

        public IEnumerable<Product> SearchByDescription(string description)
        {
            return _productService.SearchByDescription(description);
        }
    }
}
