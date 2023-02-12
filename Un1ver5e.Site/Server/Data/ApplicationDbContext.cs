using ArkLens.Models.Drafts;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Un1ver5e.Site.Server.Data.Interfaces;
using Un1ver5e.Site.Server.Models;

namespace Un1ver5e.Site.Server.Data;

/// <summary>
/// The default <see cref="DbContext"/> type for this app.
/// </summary>
public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>,
	IRepository<OwnedCharacterDraftSnapshot>
{
	/// <summary>
	/// The DbSet of <see cref="CharacterDraft"/>.
	/// </summary>
	public DbSet<OwnedCharacterDraftSnapshot> Characters { get; set; } = null!;

	/// <summary>
	/// Default ctor.
	/// </summary>
	/// <param name="options"></param>
	/// <param name="operationalStoreOptions"></param>
	public ApplicationDbContext(
		DbContextOptions<ApplicationDbContext> options,
		IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
	{
		///Database.MigrateAsync();
	}

	/// <inheritdoc/>
	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
	}

	/// <inheritdoc/>
	public DbContext Context => this;

	DbSet<OwnedCharacterDraftSnapshot> IRepository<OwnedCharacterDraftSnapshot>.DbSet => Characters;
}