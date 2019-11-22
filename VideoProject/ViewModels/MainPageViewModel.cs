using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Windows.Web.Http;

namespace VideoProject
{
    /// <summary>
    /// Main page view model
    /// </summary>
    public class MainPageViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPageViewModel"/> class.
        /// </summary>
        /// <param name="videos">(Optional) A list of preloaded videos</param>
        public MainPageViewModel(List<Video> videos)
        {
            // Setup the retrieve command
            this.RetreiveVideoDataCommand = new Command(this.RetrieveVideoData);

            if (videos != null)
            {
                // We have preloaded videos already, just create a simple task and return these
                var immediateTask = Task.Factory.StartNew(() => { return videos; });
                this.Videos = new TaskNotifier<List<Video>>(immediateTask);
            }
            else
            {
                // No preloaded videos so lets go and get them
                this.RetrieveVideoData();
            }
        }

        /// <summary>
        /// Gets the videos
        /// </summary>
        public TaskNotifier<List<Video>> Videos { get; private set; }

        /// <summary>
        /// Gets the command to retrieve video data
        /// </summary>
        public Command RetreiveVideoDataCommand { get; private set; }

        /// <summary>
        /// Creates a new TaskNotifier object with the task of getting the video data
        /// </summary>
        public void RetrieveVideoData()
        {
            this.Videos = new TaskNotifier<List<Video>>(this.GetVideos());
        }

        /// <summary>
        /// Retrieves the video json and deserializes the json to a video list
        /// </summary>
        /// <returns>The list of videos</returns>
        private async Task<List<Video>> GetVideos()
        {
            // Get the video data as JSON and deserialize it to a list of Video models
            var json = await this.GetVideoJson();
            var videos = JsonConvert.DeserializeObject<List<Video>>(json);

            // To make things easier, lets store away the related video models
            foreach (var video in videos)
            {
                video.SetupRelatedVideos(videos);
            }

            // Order them by title and return
            return videos.OrderBy(v => v.Title).ToList();
        }

        /// <summary>
        /// Gets the video json payload
        /// </summary>
        /// <returns>The json</returns>
        private async Task<string> GetVideoJson()
        {
            // Create the HTTP client and reponse URL
            HttpClient httpClient = new HttpClient();
            Uri requestUri = new Uri("https://assets.acmeaom.com/interview-project/uwpvideos.json");
            HttpResponseMessage httpResponse = new HttpResponseMessage();

            // Make the GET request and return the JSON as a string
            httpResponse = await httpClient.GetAsync(requestUri);
            httpResponse.EnsureSuccessStatusCode();
            return httpResponse.Content.ReadAsStringAsync().GetResults();
        }
    }
}
