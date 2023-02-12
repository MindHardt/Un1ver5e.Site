using System.ComponentModel.DataAnnotations;

namespace Un1ver5e.Site.Server.Data.Entities;

/// <summary>
/// Implements generic type ID property for database entities.
/// </summary>
/// <typeparam name="TId">The primary key property type.</typeparam>
public interface IDbEntity<TId>
{
	/// <summary>
	/// The database ID of this <see cref="IDbEntity{TId}"/>.
	/// </summary>
	[Key]
	public TId Id { get; set; }
}
