using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
            if (videos != null)
            {
                // We have preloaded videos already, just create a simple task and return these
                var immediateTask = Task.Factory.StartNew(() => { return videos; });
                this.Videos = new TaskNotifier<List<Video>>(immediateTask);
            }
            else
            {
                // No preloaded videos so lets go and get them
                this.Videos = new TaskNotifier<List<Video>>(this.GetVideos());
            }
        }

        /// <summary>
        /// Gets the videos
        /// </summary>
        public TaskNotifier<List<Video>> Videos { get; private set; }

        /// <summary>
        /// Retrieves the video json and deserializes the json to a video list
        /// </summary>
        /// <returns>The list of videos</returns>
        private async Task<List<Video>> GetVideos()
        {
            var json = await this.GetVideoJson();
            var videos = JsonConvert.DeserializeObject<List<Video>>(json);
            return videos.OrderBy(v => v.Title).ToList();
        }

        /// <summary>
        /// Gets the video json payload
        /// </summary>
        /// <returns>The json</returns>
        private async Task<string> GetVideoJson()
        {
            HttpClient httpClient = new HttpClient();
            Uri requestUri = new Uri("https://assets.acmeaom.com/interview-project/uwpvideos.json");
            HttpResponseMessage httpResponse = new HttpResponseMessage();

            httpResponse = await httpClient.GetAsync(requestUri);
            httpResponse.EnsureSuccessStatusCode();
            return httpResponse.Content.ReadAsStringAsync().GetResults();
        }
    }
}
