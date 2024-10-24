using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Schoolar.Core;
using Schoolar.infrastructure;
using Schoolar.infrastructure.Persistence;
using Schoolar.Service;
using System.Globalization;

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
					.AddCoreDependencies()
					.AddLocalizationServices();

			return services;
		}
		private static IServiceCollection AddSwaggerServices(this IServiceCollection services)
		{
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen();

			return services;
		}

		private static IServiceCollection AddLocalizationServices(this IServiceCollection services)
		{
			services.AddControllersWithViews()
					.AddViewLocalization(option =>
					{
						option.ResourcesPath = "";
					});
					services.Configure<RequestLocalizationOptions>(options =>
					{
						List<CultureInfo> supportedCultures = new List<CultureInfo>
						{
							new CultureInfo("en-US"),
							new CultureInfo("de-DE"),
							new CultureInfo("fr-FR"),
							new CultureInfo("ar-EG")
						};
						options.DefaultRequestCulture = new RequestCulture("en-US");
						options.SupportedCultures = supportedCultures;
						options.SupportedUICultures = supportedCultures;
					});

			return services;
		}
	}
}
