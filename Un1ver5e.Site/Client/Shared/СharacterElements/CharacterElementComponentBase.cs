using ArkLens.Models.Drafts;
using Microsoft.AspNetCore.Components;

namespace Un1ver5e.Site.Client.Shared.СharacterElements;

public class CharacterElementComponentBase : ComponentBase
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
	
	/// <summary>
	/// The draft being displayed.
	/// </summary>
	[Parameter]
	public CharacterDraft Draft { get; set; }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}
