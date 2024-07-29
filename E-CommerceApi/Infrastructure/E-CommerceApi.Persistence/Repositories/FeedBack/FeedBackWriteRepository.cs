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
    public class FeedBackWriteRepository : WriteRepository<FeedBack>, IFeedBackWriteRepository
    {
        public FeedBackWriteRepository(E_CommerceDbContext context) : base(context)
        {

        }
    }
}
