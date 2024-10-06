using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Schoolar.Core.Behaviors;
using Schoolar.infrastructure.Abstracts;
using Schoolar.infrastructure.Repositories;
using System.Reflection;

namespace Schoolar.Core
{
	public static class ModuleCoreDependencies
	{
		public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
		{
			services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

			services.AddAutoMapper(Assembly.GetExecutingAssembly());

			services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

			return services;
		}
	}
}
