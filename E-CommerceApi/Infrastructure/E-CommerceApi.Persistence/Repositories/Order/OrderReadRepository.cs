using E_CommerceApi.Application.Repositories;
using E_CommerceApi.Domain.Entities;
using E_CommerceApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceApi.Persistence.Repositories
{
    public class OrderReadRepository : ReadRepository<Order>, IOrderReadRepository
    {
        public OrderReadRepository(E_CommerceDbContext context) : base(context)
        {
        }
    }
}
