using E_CommerceApi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceApi.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<E_CommerceDbContext>
    {
        public E_CommerceDbContext CreateDbContext(string[] args)
        {
          
            DbContextOptionsBuilder<E_CommerceDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectingString);
            return new E_CommerceDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
