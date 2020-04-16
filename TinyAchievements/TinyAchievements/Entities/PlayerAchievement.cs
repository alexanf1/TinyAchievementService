using System;

namespace TinyAchievements.Entities
{
    /// <summary>
    /// An entity object that represent player achievement data
    /// </summary>
    public class PlayerAchievement : Achievement
    {
        /// <summary>
        /// Determins if this player achievement has been earned
        /// </summary>
        public bool Earned { get; set; }
    }
}
