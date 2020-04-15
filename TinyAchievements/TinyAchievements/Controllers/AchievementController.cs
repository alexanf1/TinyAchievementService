using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TinyAchievements.Entities;
using TinyAchievements.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace TinyAchievements.Controllers
{
    /// <summary>
    /// Allows the caller to assert and perform CRUD operations against achievements
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AchievementController : ControllerBase
    {
        private readonly IAchievementRepository _achievementRepository;

        /// <summary>
        /// Creates a new controller, injecting the specified dependencies
        /// </summary>
        /// <param name="achievementRepository"></param>
        public AchievementController(IAchievementRepository achievementRepository)
        {
            _achievementRepository = achievementRepository;
        }

        /// <summary>
        /// Gets all the achievements 
        /// </summary>
        /// <returns>A collection of Achievements; error otherwise</returns>
        /// <response code="200">All Achievements were found successfully.</response>
        /// <response code="404">No Achievements could be found. The returned error message provides further details</response>
        [HttpGet]
        [ProducesResponseType(typeof(Achievement[]), 200/*Ok*/)]
        [ProducesResponseType(typeof(void), 404/*NotFound*/)]
        public async Task<ActionResult<string>> Get()
        {
            Achievement[] achievements = await _achievementRepository.GetAchievements();
            if (achievements == null)
                return NotFound();

            return Ok(achievements);
        }

        /// <summary>
        /// Gets a specific Achievement based on an identifier
        /// </summary>
        /// <param name="id">unique identifier for the achievement</param>
        /// <returns>An Achievement, if the identifer was valid; error otherwise</returns>
        /// <response code="200">Achievement was found successfully.</response>
        /// <response code="404">Achievement could not be found. The returned error message provides further details</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Achievement), 200/*Ok*/)]
        [ProducesResponseType(typeof(void), 404/*NotFound*/)]
        public async Task<ActionResult<string>> Get([Required] int id)
        {
            Achievement achievement = await _achievementRepository.GetAchievement(id);
            if (achievement == null)
                return NotFound(new
                {
                    id = $"No {nameof(Achievement)} was found with the specified {nameof(id)}."
                });

            return Ok(achievement);
        }
    }
}
