using Microsoft.Extensions.DependencyInjection;
using Schoolar.infrastructure.Abstracts;
using Schoolar.infrastructure.Bases;
using Schoolar.infrastructure.Repositories;

namespace Schoolar.infrastructure
{
	public static class ModuleInfrastructureDependencies
	{
		public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
		{
			services.AddScoped<IStudentRepository, StudentRepository>();
			services.AddScoped<IDepartmentRepository, DepartmentRepository>();
			services.AddScoped<IInstructorRepository, InstructorRepository>();
			services.AddScoped<ISubjectRepository, SubjectRepository>();
			services.AddScoped(typeof(IGenericReposatoriyAsync<>), typeof(GenericRepositoryAsync<>));
			return services;
		}
	}
}
