using ArkLens.Models.Drafts;
using ArkLens.Models.Snapshots;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using Un1ver5e.Site.Server.Models;

namespace Un1ver5e.Site.Server.Data;

/// <summary>
/// The default <see cref="DbContext"/> type for this app.
/// </summary>
public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
{
	/// <summary>
	/// The DbSet of <see cref="CharacterDraft"/>.
	/// </summary>
	public DbSet<CharacterSnapshot> Characters { get; set; } = null!;

	/// <summary>
	/// Default ctor.
	/// </summary>
	/// <param name="options"></param>
	/// <param name="operationalStoreOptions"></param>
	public ApplicationDbContext(
		DbContextOptions<ApplicationDbContext> options,
		IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
	{
		//Database.MigrateAsync();
	}

	/// <inheritdoc/>
	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		builder.Entity<ApplicationUser>()
			.HasMany(u => u.Characters)
			.WithOne()
			.IsRequired()
			.OnDelete(DeleteBehavior.NoAction);

		builder.Entity<CharacterSnapshot>()
			.HasKey(cs => cs.Name);

		builder.Entity<CharacterSnapshot>()
			.ToTable("CharacterSnapshot");
	}
}