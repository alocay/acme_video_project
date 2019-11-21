namespace VideoProject
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices.WindowsRuntime;
    using Windows.Foundation;
    using Windows.Foundation.Collections;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Navigation;

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
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            List<Video> videos = e.Parameter as List<Video>;
            this.ViewModel = new MainPageViewModel(videos);
        }

        /// <summary>
        /// Video list click handler.
        /// Navigates to the video details page.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args</param>
        private void VideoList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var video = e.ClickedItem as Video;
            var haveVideos = this.ViewModel.Videos.IsCompleted && this.ViewModel.Videos.Result != null;

            if (video != null && haveVideos)
            {
                this.Frame.Navigate(typeof(VideoDetailsGallery), new VideoDetailParams() { Videos = this.ViewModel.Videos.Result, SelectedVideo = video });
            }
        }
    }
}
