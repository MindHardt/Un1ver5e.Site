using Un1ver5e.Site.Server.Data.Interfaces;

namespace Un1ver5e.Site.Server.Data;

/// <summary>
/// Contains helper method for adding all <see cref="Interfaces.IRepository{T}"/> 
/// that <see cref="Microsoft.EntityFrameworkCore.DbContext"/> implements.
/// </summary>
public static class ServiceCollectionExtensions
{
	/// <summary>
	/// Registers all <see cref="IRepository{T}"/> that <typeparamref name="TContext"/>
	/// implements.
	/// </summary>
	/// <typeparam name="TContext"></typeparam>
	/// <param name="services"></param>
	/// <returns></returns>
	public static IServiceCollection AddRepositories<TContext>(this IServiceCollection services)
	{
		var repo = typeof(IRepository<>);
		var interfaces = typeof(TContext)
			.GetInterfaces()
			.Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == repo);

		foreach (var @interface in interfaces) 
		{ 
			services.AddScoped(@interface, typeof(TContext));
		}

		return services;
	}
}
