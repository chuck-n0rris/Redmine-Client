namespace Redmine.Client.Ui.Mvvm
{
    using System.Collections.Generic;
    using System.ComponentModel;

    using Redmine.Client.Ui.Common;

    /// <summary>
    /// Base class for presentation/view models
    /// </summary>
    public abstract class NotifyingModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Dictionary of all view model property values.
        /// </summary>
        protected readonly Dictionary<string, object> PropertyValues = new Dictionary<string, object>();

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the property changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        public void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                UiThread.Dispatch(() =>
                    {
                        // Check to avoid null reference exception in case the user had
                        // to switch to another view while the first one has been loading
                        if (this.PropertyChanged != null)
                            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                    });
            }
        }

        /// <summary>
        /// Sets the value and raise property changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="value">The value.</param>
        protected internal virtual void SetValueAndRaisePropertyChanged(string propertyName, object value)
        {
            if (this.PropertyValues.ContainsKey(propertyName))
            {
                this.PropertyValues[propertyName] = value;
            }
            else
            {
                this.PropertyValues.Add(propertyName, value);
            }

            this.OnPropertyChanged(propertyName);
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>Value of the specified property if matched, otherwise null</returns>
        protected internal virtual object GetValue(string propertyName)
        {
            if (this.PropertyValues.ContainsKey(propertyName))
            {
                return this.PropertyValues[propertyName];
            }

            return null;
        }
    }
}
