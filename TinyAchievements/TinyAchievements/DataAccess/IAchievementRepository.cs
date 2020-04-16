using System;
using System.Threading.Tasks;
using TinyAchievements.Entities;

namespace TinyAchievements.DataAccess
{
    /// <summary>
    /// An interface for the IAchievementRepository
    /// </summary>
    public interface IAchievementRepository
    {
        /// <summary>
        /// Retrieves all the things
        /// </summary>
        /// <returns>A collection of all the achievements</returns>
        Task<Achievement[]> GetAchievements();

        /// <summary>
        /// Gets an achievement based on its identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A specific achievement with a matching identifier</returns>
        Task<Achievement> GetAchievement(Guid id);

        /// <summary>
        /// Gets all player achievement data based playerId
        /// </summary>
        /// <param name="playerId"></param>
        /// <param name="achievementId"></param>
        /// <returns></returns>
        Task<PlayerAchievement[]> GetPlayerAchievements(Guid playerId);
    }
}
