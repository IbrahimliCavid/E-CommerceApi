using E_CommerceApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using E_CommerceApi.Domain.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_CommerceApi.Application.Repositories;

namespace E_CommerceApi.Persistence.Repositories
{
    public class FeedBackReadRepository : ReadRepository<FeedBack>, IFeedBackReadRepository
    {
        public FeedBackReadRepository(E_CommerceDbContext context) : base(context)
        {

        }
    }
}
