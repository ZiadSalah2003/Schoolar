using Microsoft.Extensions.DependencyInjection;
using Schoolar.infrastructure.Abstracts;
using Schoolar.infrastructure.Repositories;
using Schoolar.Service.Abstracts;
using Schoolar.Service.Implementations;

namespace Schoolar.Service
{
	public static class ModuleServiceDependencies
	{
		public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
		{
			services.AddScoped<IStudentService, StudentService>();
			services.AddScoped<IDepartmentService, DepartmentService>();
			return services;
		}
	}
}
