using System.Collections.Generic;

namespace VideoProject
{
    /// <summary>
    /// The parameters provided to the video details page
    /// </summary>
    public class VideoDetailParams
    {
        /// <summary>
        /// Gets or sets the selected video
        /// </summary>
        public Video SelectedVideo { get; set; }

        /// <summary>
        /// Gets or sets the videos
        /// </summary>
        public List<Video> Videos { get; set; }
    }
}
