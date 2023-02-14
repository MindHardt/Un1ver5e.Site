using System.Security.Claims;

namespace Un1ver5e.Site.Server;

/// <summary>
/// Contains various extension methods.
/// </summary>
public static class Extensions
{
	private const string NameClaim = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";

	/// <summary>
	/// Gets name (id) of the <paramref name="principal"/> from proper claim.
	/// </summary>
	/// <param name="principal"></param>
	/// <returns></returns>
	public static string? GetUserName(this ClaimsPrincipal principal)
		=> principal.FindFirst(NameClaim)?.Value;
}
