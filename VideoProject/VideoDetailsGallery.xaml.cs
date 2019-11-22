using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace VideoProject
{
    /// <summary>
    /// The video viewer page
    /// </summary>
    public sealed partial class VideoDetailsGallery : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VideoDetailsGallery"/> class.
        /// </summary>
        public VideoDetailsGallery()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the video details view model
        /// </summary>
        public VideoDetailsViewModel ViewModel { get; set; }

        /// <summary>
        /// The navigated to handler. Sets up the view model for the video details page.
        /// </summary>
        /// <param name="e">The event args</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // Get the navigational parameters which will be used for setting up the gallery
            VideoDetailParams videoDetailParams = e.Parameter as VideoDetailParams;
            if (videoDetailParams == null)
            {
                // Throw here so we are aware since this should not happen ever
                throw new Exception("Unexpected parameters provided to video details page");
            }

            this.ViewModel = new VideoDetailsViewModel(videoDetailParams.SelectedVideo, videoDetailParams.Videos);
        }

        private void ReturnToList_Click(object sender, RoutedEventArgs e)
        {
            // Navigate back to the main page with the stored list of videos (avoid reloading)
            this.Frame.Navigate(typeof(MainPage), this.ViewModel.Videos);
        }
    }
}
