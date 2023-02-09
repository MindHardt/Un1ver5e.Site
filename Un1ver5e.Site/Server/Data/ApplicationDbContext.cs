using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Un1ver5e.Site.Server.Models;

namespace Un1ver5e.Site.Server.Data;

/// <summary>
/// The default <see cref="DbContext"/> type for this app.
/// </summary>
public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
{
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
}