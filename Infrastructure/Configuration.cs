using Infrastructure.Database.Abstractions.Picket;
using Infrastructure.Database.Abstractions.Platform;
using Infrastructure.Database.Abstractions.Warehouse;
using Infrastructure.Database.Repositories.Picket;
using Infrastructure.Database.Repositories.Platform;
using Infrastructure.Database.Repositories.WareHouse;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
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
