using Application;
using Infrastructure.Data;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<PgContext>(options =>
{
	options.UseNpgsql(builder.Configuration.GetConnectionString("Pgsql"));
});

builder.Services.AddInfrastructure();
builder.Services.AddApplication();

#region swagger

builder.Services.AddControllers()
	 .AddJsonOptions(options =>
	 {
		 options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
	 }); 

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
	var mainXmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
	var mainXmlPath = Path.Combine(AppContext.BaseDirectory, mainXmlFile);
	option.IncludeXmlComments(mainXmlPath);

	// Подключаем XML документацию зависимого проекта
	var dependentXmlFile = "Domain.xml"; // Имя XML-файла зависимого проекта
	var dependentXmlPath = Path.Combine(AppContext.BaseDirectory, dependentXmlFile);
	option.IncludeXmlComments(dependentXmlPath);
});

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseHsts();

	#region swagger
	app.UseSwagger();
	app.UseSwaggerUI(c =>
	{
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
		c.RoutePrefix = string.Empty;  // Swagger UI будет доступен по корневому пути
	});

	#endregion
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
