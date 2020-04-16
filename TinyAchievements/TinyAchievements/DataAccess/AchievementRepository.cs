using System.Threading.Tasks;
using TinyAchievements.Entities;
using TinyAchievements.Commons.DataAccess;
using Dapper.Contrib.Extensions;
using Dapper;
using System.Linq;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Logging;
using System;

namespace TinyAchievements.DataAccess
{
    /// <summary>
    /// This repository deals with all interactions with the mysql database
    /// </summary>
    public class AchievementRepository : IAchievementRepository
    {
        private readonly MySqlConnectionHelper _mySqlConnectionHelper;
        private readonly ILogger<AchievementRepository> _logger;

        /// <summary>
        /// Creates a new repository, which will access data using the given factory
        /// </summary>
        /// <param name="helper"></param>
        public AchievementRepository(MySqlConnectionHelper helper, ILogger<AchievementRepository> logger)
        {
            _mySqlConnectionHelper = helper;
            _logger = logger;
        }

        /// <inheritdoc />
        public async Task<Achievement[]> GetAchievements()
        {
            try
            {
                using (var conn = _mySqlConnectionHelper.GetConnection())
                {
                    var achievements = await conn.QueryAsync<Achievement>(
                        @"SELECT a.* FROM TinyAchievements.Achievement a");

                    return achievements as Achievement[] ?? achievements.ToArray();
                }
            }
            catch(MySqlException e)
            {
                _logger.LogError(e.Message + "Check appsettings.json and make sure your ConnectionStrings to " +
                    "MySql are correct. Your localhost, port, username and/or password may also be incorrect.");
            }

            return null;
        }

        /// <inheritdoc />
        public async Task<Achievement> GetAchievement(Guid id)
        {
            try
            {
                using (var conn = _mySqlConnectionHelper.GetConnection())
                {
                    return await conn.GetAsync<Achievement>(id);
                }
            }
            catch(MySqlException e)
            {
                _logger.LogError(e.Message + "Check appsettings.json and make sure your ConnectionStrings to " +
                    "MySql are correct. Your localhost, port, username and/or password may also be incorrect.");
            }

            return null;
        }

        /// <inheritdoc />
        public async Task<PlayerAchievement[]> GetPlayerAchievements(Guid playerId)
        {
            try
            {
                using (var conn = _mySqlConnectionHelper.GetConnection())
                {
                    var playerAchievements = await conn.QueryAsync<PlayerAchievement>(
                        @"
                        SELECT t2.*, t1.Earned 
                        FROM tinyachievements.playerachievement t1
                        INNER JOIN
                        tinyachievements.achievement t2
                        ON
                        t1.AchievementId = t2.Id
                        WHERE PlayerId = ?playerId", 
                        new { playerId });

                    return playerAchievements as PlayerAchievement[] ?? playerAchievements.ToArray();
                }
            }
            catch (MySqlException e)
            {
                _logger.LogError(e.Message + "Check appsettings.json and make sure your ConnectionStrings to " +
                    "MySql are correct. Your localhost, port, username and/or password may also be incorrect.");
            }

            return null;
        }
    }
}
