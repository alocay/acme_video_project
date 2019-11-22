using System.Collections.Generic;

namespace VideoProject
{
    /// <summary>
    /// The video details view model class
    /// </summary>
    public class VideoDetailsViewModel : NotifyClass
    {
        /// <summary>
        /// The current video
        /// </summary>
        private Video currentVideo = null;

        /// <summary>
        /// The list of videos
        /// </summary>
        private List<Video> videos = new List<Video>();

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoDetailsViewModel"/> class.
        /// </summary>
        /// <param name="video">The initially viewed video</param>
        /// <param name="videos">The video list</param>
        public VideoDetailsViewModel(Video video, List<Video> videos)
        {
            this.CurrentVideo = video;
            this.Videos = videos;
        }

        /// <summary>
        /// Gets or sets the current video displayed
        /// </summary>
        public Video CurrentVideo
        {
            get
            {
                return this.currentVideo;
            }

            set
            {
                this.currentVideo = value;
                this.NotifyChanged("CurrentVideo");
            }
        }

        /// <summary>
        /// Gets the list of videos
        /// </summary>
        public List<Video> Videos { get; private set; }
    }
}
