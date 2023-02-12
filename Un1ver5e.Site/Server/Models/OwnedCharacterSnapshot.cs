using ArkLens.Models.Snapshots;
using Un1ver5e.Site.Server.Data.Entities;

namespace Un1ver5e.Site.Server.Models;

/// <summary>
/// The database and DTO variant of <see cref="CharacterDraftSnapshot"/>.
/// </summary>
public record OwnedCharacterDraftSnapshot :
	CharacterDraftSnapshot,
	IDbEntity<ulong>,
	IOwned<ApplicationUser, string>
{
	/// <inheritdoc/>
	public required ApplicationUser Owner { get; set; }
	/// <inheritdoc/>
	public ulong Id { get; set; }

}
