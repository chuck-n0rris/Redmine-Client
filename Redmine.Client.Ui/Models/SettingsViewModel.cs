namespace Redmine.Client.Ui.Models
{
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Redmine.Client.Ui.Common;

    /// <summary>
    /// View model for the settings page view.
    /// </summary>
    public class SettingsViewModel : TrackingChangesModel
    {
        private readonly IApplicationSettingsManager settingsManager;

        /// <summary>
        /// Initializes a new instance of the ViewModelBase class.
        /// </summary>
        /// <param name="settingsManager">The application settings manager.</param>
        public SettingsViewModel(IApplicationSettingsManager settingsManager)
        {
            this.settingsManager = settingsManager;
            
            this.SaveCommand = new RelayCommand(OnSave);
            this.RollbackCommand = new RelayCommand(OnRollback);
            this.TestConnectionCommand = new RelayCommand(OnTestConnection);
        }
        
        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        public string UserName
        {
            get { return this.GetValue(it => it.UserName); }
            set { this.SetValueAndRaisePropertyChanged(it => it.UserName, value); }
        }

        /// <summary>
        /// Gets or sets the Password.
        /// </summary>
        public string Password
        {
            get { return this.GetValue(it => it.Password); }
            set { this.SetValueAndRaisePropertyChanged(it => it.Password, value); }
        }

        /// <summary>
        /// Gets or sets the Url.
        /// </summary>
        public string Url
        {
            get { return this.GetValue(it => it.Url); }
            set { this.SetValueAndRaisePropertyChanged(it => it.Url, value); }
        }

        /// <summary>
        /// Gets or sets the AuthenticationRequired.
        /// </summary>
        public bool AuthenticationRequired
        {
            get { return this.GetValue(it => it.AuthenticationRequired); }
            set { this.SetValueAndRaisePropertyChanged(it => it.AuthenticationRequired, value); }
        }
        
        /// <summary>
        /// Gets or sets the save command.
        /// </summary>
        public ICommand SaveCommand { get; set; }

        /// <summary>
        /// Gets or sets the rollback command.
        /// </summary>
        public ICommand RollbackCommand { get; set; }

        /// <summary>
        /// Gets or sets the test connection command.
        /// </summary>
        public ICommand TestConnectionCommand { get; set; }

        /// <summary>
        /// Initializes and prepares the data for viewmodel.
        /// </summary>
        public void Initialize()
        {
            var credentials = this.settingsManager.GetConnectionSettings();
            
            this.AuthenticationRequired = credentials.AuthenticationRequired;
            this.UserName = credentials.Login;
            this.Password = credentials.Password;
            this.Url = credentials.Url;

            this.StartTracking();
        }

        /// <summary>
        /// Called on save application settings.
        /// </summary>
        private void OnSave()
        {
            var credentials = new ConnectionSettings();

            credentials.AuthenticationRequired = this.AuthenticationRequired;
            credentials.Login = this.UserName;
            credentials.Password = this.Password;
            credentials.Url = this.Url;

            this.settingsManager.SetConnectionSettings(credentials);
            this.Commit();
        }

        /// <summary>
        /// Called on rollback application settings changes.
        /// </summary>
        private void OnRollback()
        {
            this.Rollback();
        }

        /// <summary>
        /// Called on test connection command.
        /// </summary>
        private void OnTestConnection()
        {
        }
    }
}