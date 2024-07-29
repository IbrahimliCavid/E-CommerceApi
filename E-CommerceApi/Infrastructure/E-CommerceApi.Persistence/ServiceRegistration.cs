using Microsoft.EntityFrameworkCore;
using E_CommerceApi.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_CommerceApi.Application.Repositories;
using E_CommerceApi.Persistence.Repositories;

namespace E_CommerceApi.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<E_CommerceDbContext>(options => options.UseNpgsql(Configuration.ConnectingString));

            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository,  CustomerWriteRepository>();
                     
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
                     
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

            services.AddScoped<IFeedBackReadRepository, FeedBackReadRepository>();
            services.AddScoped<IFeedBackWriteRepository, FeedBackWriteRepository>();
        }
    }
}
