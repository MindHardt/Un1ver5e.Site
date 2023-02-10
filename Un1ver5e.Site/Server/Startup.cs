using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Un1ver5e.Site.Server.Data;
using Un1ver5e.Site.Server.Models;

namespace Un1ver5e.Site.Server;

/// <summary>
/// The default startup.
/// </summary>
public class Startup
{
    private readonly IConfiguration _cfg;
    private readonly IWebHostEnvironment _env;

    /// <summary>
    /// The default ctor.
    /// </summary>
    /// <param name="cfg"></param>
    /// <param name="env"></param>
    public Startup(IConfiguration cfg, IWebHostEnvironment env)
    {
        _cfg = cfg;
        _env = env;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // Add services to the container.
        const string connstrName = "DefaultConnection";
        var connectionString = _cfg.GetConnectionString(connstrName) ?? throw new InvalidOperationException($"Connection string '{connstrName}' not found.");

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddDatabaseDeveloperPageExceptionFilter();
        services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddEntityFrameworkStores<ApplicationDbContext>();
        services.AddIdentityServer()
            .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();
        services.AddAuthentication()
            .AddGoogle(googleOptions =>
            {
                var googleConfig = _cfg.GetSection("Authentication").GetSection("Google");
                googleOptions.ClientId = googleConfig["ClientId"] ?? throw new InvalidOperationException();
                googleOptions.ClientSecret = googleConfig["ClientSecret"] ?? throw new InvalidOperationException();
                //googleOptions.AuthorizationEndpoint = "signin-google";
            })
            .AddIdentityServerJwt();

        services.AddControllersWithViews();
        services.AddRazorPages();
    }

    public void Configure(IApplicationBuilder app)
    {
        if (_env.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
            app.UseWebAssemblyDebugging();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseBlazorFrameworkFiles();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseIdentityServer();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
            endpoints.MapControllers();
            endpoints.MapFallbackToFile("index.html");
        });
    }
}
