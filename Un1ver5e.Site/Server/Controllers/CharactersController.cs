using ArkLens.Models.Snapshots;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Un1ver5e.Site.Server.Data;

namespace Un1ver5e.Site.Server.Controllers
{
	[Route("api/[controller]")]
	[Authorize]
	[ApiController]
	public class CharactersController : ControllerBase
	{
		private readonly ApplicationDbContext _dbCtx;
		private readonly ILogger<CharactersController> _logger;

		public CharactersController(
			ILogger<CharactersController> logger,
			ApplicationDbContext dbCtx)
		{
			_logger = logger;
			_dbCtx = dbCtx;
		}

		[HttpPost]
		public async ValueTask<IActionResult> SaveCharacter(CharacterSnapshot character)
		{
			var userName = User.GetUserName();
			if (userName is null)
				return BadRequest("Не удалось получить ваши данные.");
			_logger.LogInformation("Saving character {CHAR}, username {USER}",
				character.Name, userName);

			var user = await _dbCtx.Users
				.Include(u => u.Characters)
				.FirstOrDefaultAsync(u => u.Id == userName);
			if (user is null)
				return BadRequest("Не найдены ваши данные, проверьте авторизованы ли вы.");
			_logger.LogInformation("Saving character {CHAR}, user {USER}",
				character.Name, user.UserName);

			var existingCharacter = await _dbCtx.Characters
				.FindAsync(character.Name);
			if (existingCharacter is not null)
			{
				_logger.LogInformation("Saving character {CHAR}, character exists",
				character.Name);

				if (user.Characters.Contains(existingCharacter) is false)
					return BadRequest($"Персонаж с именем {character.Name} уже существует и вам не принадлежит!");
				else
					_dbCtx.Characters.Remove(existingCharacter);	
			}

			user.Characters.Add(character);

			await _dbCtx.SaveChangesAsync();
			_logger.LogInformation("Saving character {CHAR}, done",
				character.Name);
			return Ok();
		}
	}
}
