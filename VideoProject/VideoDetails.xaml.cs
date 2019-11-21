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

namespace VideoProject
{
    /// <summary>
    /// The video viewer page
    /// </summary>
    public sealed partial class VideoViewer : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VideoViewer"/> class.
        /// </summary>
        public VideoViewer()
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
            this.Frame.Navigate(typeof(MainPage), this.ViewModel.Videos);
        }
    }
}
