using ArkLens.Models.Snapshots;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Un1ver5e.Site.Server.Data.Interfaces;
using Un1ver5e.Site.Server.Models;

namespace Un1ver5e.Site.Server.Controllers
{
	[Route("api/[controller]")]
	[Authorize]
	[ApiController]
	public class CharactersController : ControllerBase
	{
		private readonly IRepository<CharacterDraftSnapshot> _repo;
		private readonly ILogger<CharactersController> _logger;

		public CharactersController(IRepository<CharacterDraftSnapshot> repo, ILogger<CharactersController> logger)
		{
			_repo = repo;
			_logger = logger;
		}

		/// <summary>
		/// Saving Character draft.
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		[HttpPost]
		public async ValueTask<IActionResult> SaveCharacter(OwnedCharacterDraftSnapshot entity)
		{
			_logger.LogInformation("Saving character with name {NAME}, owner id {OWNERID} and id {ID}", 
				entity.Name, entity.Owner.Id, entity.Id);
			_repo.DbSet.Update(entity);
			await _repo.Context.SaveChangesAsync();
			_logger.LogInformation("Saved character with name {NAME}, owner id {OWNERID} and id {ID}",
				entity.Name, entity.Owner.Id, entity.Id);
			return Ok();
		}
	}
}
