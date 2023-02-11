using ArkLens.Models.Drafts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Un1ver5e.Site.Server.Data.Interfaces;

namespace Un1ver5e.Site.Server.Controllers
{
	[Route("api/[controller]")]
	[Authorize]
	[ApiController]
	public class CharacterDraftsController : ControllerBase
	{
		private readonly IRepository<CharacterDraft> _repo;
		private readonly ILogger<CharacterDraftsController> _logger;

		public CharacterDraftsController(IRepository<CharacterDraft> repo, ILogger<CharacterDraftsController> logger)
		{
			_repo = repo;
			_logger = logger;
		}

		/// <summary>
		/// Saving Character draft.
		/// </summary>
		/// <param name="draft"></param>
		/// <returns></returns>
		[HttpPost]
		public async ValueTask<IActionResult> SaveCharacter(CharacterDraft draft)
		{
			_logger.LogInformation("Saving draft with name {NAME} and id {ID}", draft.Name, draft.Id);
			_repo.DbSet.Update(draft);
			await _repo.Context.SaveChangesAsync();
			_logger.LogInformation("Saved draft with name {NAME} and id {ID}", draft.Name, draft.Id);
			return Ok();
		}
	}
}
