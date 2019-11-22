using System.ComponentModel;

namespace VideoProject
{
    /// <summary>
    /// A class that allow property binding
    /// </summary>
    public class NotifyClass : INotifyPropertyChanged
    {
        /// <summary>
        /// The property changed event handler
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        /// <summary>
        /// Notifies of a property change
        /// </summary>
        /// <param name="propertyName">The property to notify on</param>
        public void NotifyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
