﻿using E_CommerceApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceApi.Application.ViewModels.Products
{
    public class VMUpdateProduct
    {
        public string Id {  get; set; }
        public string Name { get; set; }

        public int Stock { get; set; }

        public float Price { get; set; }

 

    }
}
