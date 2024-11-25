using Application.Abstraction.Repositories.Picket;
using Application.Abstraction.Repositories.Platform;
using Application.Abstraction.Repositories.Warehouse;
using Infrastructure.Database.Repositories.Picket;
using Infrastructure.Database.Repositories.Platform;
using Infrastructure.Database.Repositories.WareHouse;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Database
{
    public static class Configuration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IPicketRepository, PicketRepository>();

            services.AddScoped<IPlatformRepository, PlatformRepository>();

            services.AddScoped<IWarehouseRepository, WareHouseRepository>();

            return services;
        }
    }
}
