
using System;

namespace TinyAchievements.Entities
{
    /// <summary>
    /// An entity object that represent achievement data
    /// </summary>
    public class Achievement
    {
        /// <summary>
        /// A unique identifier for this Achievement
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// An api identifier for this achievement
        /// </summary>
        public string ApiName { get; set; }

        /// <summary>
        /// The name of the Achievement
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The description of the Achievement
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// A JSON representation of the meta data associated with this achievement
        /// </summary>
        public string MetaData { get; set; }
    }
}
