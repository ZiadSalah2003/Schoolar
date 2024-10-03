using Microsoft.Extensions.DependencyInjection;
using Schoolar.infrastructure.Abstracts;
using Schoolar.infrastructure.Repositories;

namespace Schoolar.Service
{
	public static class ModuleServiceDependencies
	{
		public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
		{
			services.AddScoped<IStudentRepository, StudentRepository>();
			return services;
		}
	}
}
