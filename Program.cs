using DittoBox.EdgeServer.ContainerManagement.Application.Handlers.Interfaces;
using DittoBox.EdgeServer.ContainerManagement.Application.Services;
using DittoBox.EdgeServer.ContainerManagement.Domain.Services;
using DittoBox.EdgeServer.ContainerManagement.Infrastructure.Configuration;
using DittoBox.EdgeServer.ContainerManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DittoBox.EdgeServer;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		builder.Services.AddControllers();
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();
		builder.Configuration.AddUserSecrets<Program>();

		var folder = Environment.SpecialFolder.LocalApplicationData;
		var path = Environment.GetFolderPath(folder);
        var sqliteConnectionString = $"Data Source={Path.Join(path, "edge-server.db")}";

        if (string.IsNullOrEmpty(sqliteConnectionString))
		{
			throw new Exception("SQLITE_CONNECTION_STRING environment variable not set");
		}

		builder.Services.AddDbContext<ApplicationDbContext>(options =>
		{
			options.UseSqlite(sqliteConnectionString);
		});

		builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

		builder.Services.AddCors(options =>
		{
			options.AddPolicy("AllowAll", corsPolicyBuilder =>
			{
				corsPolicyBuilder.AllowAnyOrigin()
							.AllowAnyMethod()
							.AllowAnyHeader();
			});
		});

		ConfigureServices(builder);

        var app = builder.Build();
		app.UseSwagger();
		app.UseSwaggerUI();

		using (var scope = app.Services.CreateScope())
		{
			var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
			db.Database.EnsureCreated();
		}

		app.UseHttpsRedirection();

		app.UseCors("AllowAll");

		app.MapControllers();

		app.Run();

	}

	private static void ConfigureServices(WebApplicationBuilder builder)
	{
		builder.Services.AddScoped<IContainerStatusReportCommandHandler, ContainerStatusReportCommandHandler>();

		builder.Services.AddScoped<IContainerService, ContainerService>();
		builder.Services.AddScoped<IContainerRepository, ContainerRepository>();
        builder.Services.AddScoped<IContainerHealthRecordRepository, ContainerHealthRecordRepository>();
		builder.Services.AddScoped<IContainerStatusRecordRepository, ContainerStatusRecordRepository>();

		builder.Services.AddScoped<ICloudService , CloudService>();
    }
}