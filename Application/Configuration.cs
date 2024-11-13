using Application.Service.Abstraction.Picket;
using Application.Service.Abstraction.Platform;
using Application.Service.Abstraction.Warehouse;
using Application.Service.Services.Picket;
using Application.Service.Services.Platform;
using Application.Service.Services.Warehouse;
using Domain.Entity.Entitys;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
	public static class Configuration
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			services.AddScoped<IWarehouseService, WarehouseService>();
			services.AddScoped<IPlatformService, PlatformService>();
			services.AddScoped<IPicketService, PicketService>();

			return services;
		}

	}
}
