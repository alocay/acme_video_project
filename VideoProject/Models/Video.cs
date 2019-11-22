using System.Collections.Generic;
using System.Linq;
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
        public double RunningTime { get; set; }

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

        /// <summary>
        /// Gets or sets the related videos
        /// </summary>
        [JsonIgnore]
        public List<Video> RelatedVideos { get; set; } = new List<Video>();

        /// <summary>
        /// Gets the related videos based on ID
        /// </summary>
        /// <param name="videos">The video list</param>
        public void SetupRelatedVideos(List<Video> videos)
        {
            foreach (string id in this.RelatedVideoIds)
            {
                var video = videos.FirstOrDefault(v => v.Id == id);

                if (video != null)
                {
                    this.RelatedVideos.Add(video);
                }
            }
        }
    }
}