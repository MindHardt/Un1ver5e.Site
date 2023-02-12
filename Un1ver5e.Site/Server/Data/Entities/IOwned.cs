using Microsoft.AspNetCore.Identity;

namespace Un1ver5e.Site.Server.Data.Entities;

/// <summary>
/// Implements reference to <see cref="IdentityUser{TKey}"/>.
/// </summary>
/// <typeparam name="TUser">The <see cref="IdentityUser{TKey}"/> implementation.</typeparam>
/// <typeparam name="TUserKey">The primary key of <typeparamref name="TUser"/>.</typeparam>
public interface IOwned<TUser, TUserKey>

	where TUser : IdentityUser<TUserKey>
	where TUserKey : IEquatable<TUserKey>
{
	/// <summary>
	/// The owner of this <see cref="IOwned{TUser, TUserKey}"/>.
	/// </summary>
	public TUser Owner { get; set; }
}
