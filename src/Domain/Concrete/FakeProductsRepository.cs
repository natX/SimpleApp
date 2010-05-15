using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Abstract;
using Domain.Entities;

namespace Domain.Concrete
{
    public class FakeProductsRepository
        : IProductsRepository
    {
        private static IQueryable<Product> _fakeProducts = 
            new List<Product>
            {
                new Product {Name = "Football", Price = 25},       
                new Product {Name = "Surf board", Price = 179},
                new Product {Name = "Running Shoes", Price = 90}
            }.AsQueryable();

        public IQueryable<Product> Products
        {
            get { return _fakeProducts; }
        }
    }
}