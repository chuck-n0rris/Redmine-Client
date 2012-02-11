namespace Redmine.Client.Ui.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Provides tracking changes in view model.
    /// </summary>
    public class TrackingChangesModel : NotifyingModelBase
    {
        private readonly Dictionary<string, object> startTrackingValues;
        private readonly List<string> trackingProperties;
        private bool isTracking;
        private bool changed;

        /// <summary>
        /// Initializes a new instance of the <see cref="TrackingChangesModel"/> class.
        /// </summary>
        public TrackingChangesModel()
        {
            this.trackingProperties = new List<string>();
            this.startTrackingValues = new Dictionary<string, object>();
            isTracking = false;
        }

        /// <summary>
        /// Gets or sets the IsChanged.
        /// </summary>
        public bool Changed
        {
            get
            {
                return this.changed;
            }

            set
            {
                this.changed = value;
                this.OnPropertyChanged("Changed");
            }
        }

        /// <summary>
        /// Sets the tracking properties.
        /// </summary>
        /// <param name="properties">The properties.</param>
        public void SetTrackingProperties(string[] properties)
        {
            foreach (var property in properties)
            {
                this.trackingProperties.Add(property);
            }
        }

        /// <summary>
        /// Starts the tracking.
        /// </summary>
        public void StartTracking()
        {
            this.isTracking = true;
            SetStartTrackingPropertyValues();
        }

        /// <summary>
        /// Commits properties changes.
        /// </summary>
        public void Commit()
        {
            SetStartTrackingPropertyValues();
            RaiseChangedIfTrackingPropertiesHaveChanges();
        }

        /// <summary>
        /// Rollbacks properties changes.
        /// </summary>
        public void Rollback()
        {
            foreach (var trackingValue in this.startTrackingValues)
            {
                this.SetValueAndRaisePropertyChanged(trackingValue.Key, trackingValue.Value);
            }
        }

        /// <summary>
        /// Sets the value and raise property changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="value">The value.</param>
        protected internal override void SetValueAndRaisePropertyChanged(string propertyName, object value)
        {
            if (isTracking)
            {
                if (!this.PropertyValues.ContainsKey(propertyName))
                    AddPropertyInitializedAsDefault(propertyName, value);
            }

            base.SetValueAndRaisePropertyChanged(propertyName, value);

            if (isTracking)
            {
                RaiseChangedIfTrackingPropertiesHaveChanges();
            }
        }

        /// <summary>
        /// Raises the changed if tracking properties have changes.
        /// </summary>
        private void RaiseChangedIfTrackingPropertiesHaveChanges()
        {
            foreach (var trackingProp in startTrackingValues)
            {
                var propertyValue = this.GetValue(trackingProp.Key);
                if (!propertyValue.Equals(trackingProp.Value))
                {
                    this.Changed = true;
                    return;
                }
            }

            this.Changed = false;
        }
        
        /// <summary>
        /// Adds the property initialized as default.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="value">The value.</param>
        private void AddPropertyInitializedAsDefault(string propertyName, object value)
        {
            object startValue = null;
            if (value != null)
            {
                var type = value.GetType();

                if (type.IsValueType)
                {
                    startValue = Activator.CreateInstance(type);
                }
            }

            this.startTrackingValues.Add(propertyName, startValue);
        }

        /// <summary>
        /// Sets the start tracking properties.
        /// </summary>
        private void SetStartTrackingPropertyValues()
        {
            this.startTrackingValues.Clear();
            foreach (var propertyValue in PropertyValues)
            {
                this.startTrackingValues.Add(propertyValue.Key, this.GetValue(propertyValue.Key));
            }
        }
    }
}