using Microsoft.EntityFrameworkCore;

namespace Un1ver5e.Site.Server.Data.Interfaces;

/// <summary>
/// Abstracts <see cref="DbContext"/> and its single <see cref="DbSet{TEntity}"/> property.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IRepository<T>
	where T : class
{
	/// <summary>
	/// The DbSet of <typeparamref name="T"/>.
	/// </summary>
	public DbSet<T> DbSet { get; }
	/// <summary>
	/// The context used for saving data and accessing database.
	/// </summary>
	public DbContext Context { get; }
}
