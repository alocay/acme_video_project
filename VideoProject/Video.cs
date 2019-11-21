using System.Collections.Generic;
using Newtonsoft.Json;

namespace VideoProject
{
    /// <summary>
    /// The video model class
    /// </summary>
    public class Video
    {
        /// <summary>
        /// Gets or sets the title
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the bullet text
        /// </summary>
        [JsonProperty("bulletText")]
        public string BulletText { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the running time
        /// </summary>
        [JsonProperty("runningTime")]
        public float RunningTime { get; set; }

        /// <summary>
        /// Gets or sets the art url
        /// </summary>
        [JsonProperty("artUrl")]
        public string ArtUrl { get; set; }

        /// <summary>
        /// Gets or sets related movie IDs
        /// </summary>
        [JsonProperty("related")]
        public List<string> RelatedVideoIds { get; set; }
    }
}