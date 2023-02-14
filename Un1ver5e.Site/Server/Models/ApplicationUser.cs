using ArkLens.Models.Snapshots;
using Microsoft.AspNetCore.Identity;
using System.Security.Principal;

namespace Un1ver5e.Site.Server.Models;

/// <summary>
/// Stores information about application users.
/// </summary>
public class ApplicationUser : IdentityUser
{
	/// <summary>
	/// All the <see cref="CharacterSnapshot"/>s owned by this <see cref="ApplicationUser"/>.
	/// </summary>
	public List<CharacterSnapshot> Characters { get; set; } = new();
}