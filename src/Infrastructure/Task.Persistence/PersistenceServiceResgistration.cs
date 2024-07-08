using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Contracts.Persistence;
using Task.Persistence.Data;
using Task.Persistence.Repositories;

namespace Task.Persistence
{
    public static class PersistenceServiceResgistration
    {
        public static IServiceCollection AddPersistanceService(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<TaskContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("DevConnection"));
            });
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IStoreItemRepository, StoreItemRepository>();
            return services;
        }
    }
}
