using Application.Service.Abstraction.Picket;
using Application.Service.Abstraction.Platform;
using Application.Service.Abstraction.Warehouse;
using Application.Service.Services.Picket;
using Application.Service.Services.Platform;
using Application.Service.Services.Warehouse;
using Application.Validation;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;


namespace Application
{
	public static class Configuration
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			services.AddScoped<IWarehouseService, WarehouseService>();
			services.AddScoped<IPlatformService, PlatformService>();
			services.AddScoped<IPicketService, PicketService>();

			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddValidatorsFromAssemblyContaining<PlatformAddValidator>();

            return services;
		}

	}
}
