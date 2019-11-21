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
    /// Video details user control
    /// </summary>
    public sealed partial class VideoDetails : UserControl
    {
        /// <summary>
        /// The title property dependency property
        /// </summary>
        private readonly DependencyProperty titleProperty = DependencyProperty.Register("Title", typeof(string), typeof(VideoDetails), new PropertyMetadata(string.Empty));

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoDetails"/> class.
        /// </summary>
        public VideoDetails()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the title property
        /// </summary>
        public string Title
        {
            get { return this.GetValue(this.titleProperty).ToString(); }
            set { this.SetValue(this.titleProperty, value);  }
        }
    }
}
