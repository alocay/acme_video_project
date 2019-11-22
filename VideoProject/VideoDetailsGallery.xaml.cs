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

            this.DataContext = new VideoDetailsViewModel(videoDetailParams.SelectedVideo, videoDetailParams.Videos);
        }

        /// <summary>
        /// Return to list click handler
        /// </summary>
        /// <param name="sender">The snder</param>
        /// <param name="e">Event args</param>
        private void ReturnToList_Click(object sender, RoutedEventArgs e)
        {
            // Navigate back to the main page with the stored list of videos (avoid reloading)
            var viewModel = this.GetViewModel();
            this.Frame.Navigate(typeof(MainPage), viewModel.Videos);
        }

        /// <summary>
        /// Listview item click handler
        /// Note: Without extra research, this will have to handled in the code=behind rather than int he viewmodel
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">Event args</param>
        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var video = e.ClickedItem as Video;
            if (video == null)
            {
                return;
            }

            // Update the current video
            var viewModel = this.GetViewModel();
            viewModel.CurrentVideo = video;
        }

        /// <summary>
        /// Gets the view model from the data context
        /// </summary>
        /// <returns>The view model</returns>
        private VideoDetailsViewModel GetViewModel()
        {
            // Get the video model from the context
            var viewModel = this.DataContext as VideoDetailsViewModel;
            if (viewModel == null)
            {
                throw new Exception("DataContext for gallery was not of type VideoDetailsViewModel");
            }

            return viewModel;
        }
    }
}
