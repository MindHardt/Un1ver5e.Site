using Microsoft.JSInterop;

namespace Un1ver5e.Site.Client;

public static class IJSRuntimeExtensions
{
	public static ValueTask AlertAsync(this IJSRuntime js, string text)
		=> js.InvokeVoidAsync("alert", text);

	public static ValueTask<string> PromptAsync(this IJSRuntime js, string text)
		=> js.InvokeAsync<string>("prompt", text);

	public static ValueTask<bool> ConfirmAsync(this IJSRuntime js, string text)
		=> js.InvokeAsync<bool>("confirm", text);

	public static async ValueTask DownloadFileAsync(this IJSRuntime js, Stream stream, string fileName)
	{
		using var streamRef = new DotNetStreamReference(stream);
		await js.InvokeAsync<IJSObjectReference>("import", "./js/download.js");
		await js.InvokeVoidAsync("downloadFileFromStream", fileName, streamRef);
	}
}
