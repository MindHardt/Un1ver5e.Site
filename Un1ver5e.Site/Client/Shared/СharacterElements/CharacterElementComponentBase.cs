using ArkLens.Models.Drafts;
using Microsoft.AspNetCore.Components;

namespace Un1ver5e.Site.Client.Shared.СharacterElements;

public class CharacterElementComponentBase : ComponentBase
{
    /// <summary>
    /// The draft being displayed.
    /// </summary>
    [Parameter]
    public CharacterDraft Draft { get; set; }
}
