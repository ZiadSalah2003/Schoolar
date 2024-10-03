using Microsoft.EntityFrameworkCore;
using Schoolar.Core;
using Schoolar.infrastructure;
using Schoolar.infrastructure.Persistence;
using Schoolar.Service;

namespace Schoolar.API
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddControllers();

			var connectionStrings = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection String DefaultConnection not found.");
			services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionStrings));

			services.AddSwaggerServices();

			services.AddInfrastructureDependencies()
					.AddServiceDependencies()
					.AddCoreDependencies();

			return services;
		}
		private static IServiceCollection AddSwaggerServices(this IServiceCollection services)
		{
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen();

			return services;
		}
	}
}
