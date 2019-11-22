using System;
using Windows.UI.Xaml.Data;

namespace VideoProject
{
    /// <summary>
    /// Covnerter to convert the running time value to the display value
    /// </summary>
    public class RunningTimeDisplayConverter : IValueConverter
    {
        /// <summary>
        /// Converts the double seconds value to a display string
        /// </summary>
        /// <param name="value">The running time numeric value</param>
        /// <param name="targetType">The target type</param>
        /// <param name="parameter">The parameter</param>
        /// <param name="language">The language</param>
        /// <returns>The display string</returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is double)
            {
                var totalSeconds = (double)value;
                var timeRunInMins = Math.Round(totalSeconds / 60.0);
                return $"{timeRunInMins} mins";
            }

            return string.Empty;
        }

        /// <summary>
        /// Not implemented conversion function
        /// </summary>
        /// <param name="value">The display value</param>
        /// <param name="targetType">The target type</param>
        /// <param name="parameter">The parameter</param>
        /// <param name="language">The language</param>
        /// <returns>The original value</returns>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
