using Application.Service.Abstraction.Warehouse;
using Application.Service.Services.Warehouse;
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
			services.AddScoped<IWarehouseService, WarehouseServices>();

			return services;
		}

	}
}
