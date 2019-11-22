using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace VideoProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the main page's view model
        /// </summary>
        public MainPageViewModel ViewModel { get; set; }

        /// <summary>
        /// The navigated to handler. Sets up the view model for the main page.
        /// </summary>
        /// <param name="e">Event args</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // Get the navigation parameter - if the video list is not empty, don't bother reloading
            List<Video> videos = e.Parameter as List<Video>;
            this.DataContext = new MainPageViewModel(videos);
        }

        /// <summary>
        /// Video list click handler.
        /// Navigates to the video details page.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args</param>
        private void VideoList_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Get the clicked video and video list and pass it to the gallery page
            var video = e.ClickedItem as Video;
            var haveVideos = this.ViewModel.Videos.IsCompleted && this.ViewModel.Videos.Result != null;

            if (video != null && haveVideos)
            {
                this.Frame.Navigate(typeof(VideoDetailsGallery), new VideoDetailParams() { Videos = this.ViewModel.Videos.Result, SelectedVideo = video });
            }
        }
    }
}
