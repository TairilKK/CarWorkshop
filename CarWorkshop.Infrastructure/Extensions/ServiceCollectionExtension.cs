using CarWorkshop.Domain.Interfaces;
using CarWorkshop.Infrastructure.Persistence;
using CarWorkshop.Infrastructure.Repositories;
using CarWorkshop.Infrastructure.Seeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("CarWorkshopDbConnectionString");
            services.AddDbContext<CarWorkshopDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<CarWorkshopDbContext>();

            services.AddScoped<CarWorkshopSeeder>();
            services.AddScoped<ICarWorkshopRepository, CarWorkshopRepository>();
        }
        
    }
}
