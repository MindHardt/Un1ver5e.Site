using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

namespace Un1ver5e.Site.Client;

public static class Extensions
{
	public static ValueTask AlertAsync(this IJSRuntime js, string text, CancellationToken cancellationToken = default)
		=> js.InvokeVoidAsync("alert", cancellationToken, text);

	public static ValueTask<string> PromptAsync(this IJSRuntime js, string text, CancellationToken cancellationToken = default)
		=> js.InvokeAsync<string>("prompt", cancellationToken, text);

	public static ValueTask<bool> ConfirmAsync(this IJSRuntime js, string text, CancellationToken cancellationToken = default)
		=> js.InvokeAsync<bool>("confirm", cancellationToken, text);

	public static bool IsAuthOk(this AuthenticationState state)
		=> state.User.Identity?.IsAuthenticated is true;

	public static async ValueTask DownloadFileAsync(this IJSRuntime js, Stream stream, string fileName)
	{
		using var streamRef = new DotNetStreamReference(stream);
		await js.InvokeAsync<IJSObjectReference>("import", "./js/download.js");
		await js.InvokeVoidAsync("downloadFileFromStream", fileName, streamRef);
	}
}
