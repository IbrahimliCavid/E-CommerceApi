using E_CommerceApi.Application.Abstractions;
using E_CommerceApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceApi.Persistence.Concrets
{
    public class ProductService : IProductService
    {
        public List<Product> GetProducts() =>
            new()
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 1",
                    Stock = 1,
                    Price = 100
                } ,
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 2",
                    Stock = 2,
                    Price = 200
                }, 
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 3",
                    Stock = 3,
                    Price = 300
                } ,
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 4",
                    Stock = 4,
                    Price = 400
                }  ,
          
            };
    }
}
