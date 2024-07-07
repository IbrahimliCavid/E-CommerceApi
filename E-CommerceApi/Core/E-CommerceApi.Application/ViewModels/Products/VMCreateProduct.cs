using E_CommerceApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceApi.Application.ViewModels.Products
{
    public class VMCreateProduct
    {
        public string Name { get; set; }

        public int Stock { get; set; }

        public float Price { get; set; }

        public static Product  ToModel(VMCreateProduct viewModel)
        {
            Product model = new()
            {
                Name = viewModel.Name,
                Price = viewModel.Price,
                Stock = viewModel.Stock
            };
            return model;
        }

    }
}
