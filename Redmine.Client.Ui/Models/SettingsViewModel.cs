namespace Redmine.Client.Ui.Models
{
    using System.Windows.Input;

    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;

    using Redmine.Client.Ui.Common;

    /// <summary>
    /// View model for the settings page view.
    /// </summary>
    public class SettingsViewModel : ViewModelBase
    {
        private readonly IApplicationSettingsManager settingsManager;

        private string userName;
        private string password;
        private string url;

        /// <summary>
        /// Initializes a new instance of the ViewModelBase class.
        /// </summary>
        /// <param name="settingsManager">The application settings manager.</param>
        public SettingsViewModel(IApplicationSettingsManager settingsManager)
        {
            this.settingsManager = settingsManager;
            
            this.SaveCommand = new RelayCommand(OnSave);
        }

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        public string UserName
        {
            get
            {
                return this.userName;
            }

            set
            {
                this.userName = value; 
                this.RaisePropertyChanged("UserName");
            }
        }
        
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                this.password = value;
                this.RaisePropertyChanged("Password");
            }
        }
        
        /// <summary>
        /// Gets or sets the Url.
        /// </summary>
        public string Url
        {
            get
            {
                return this.url;
            }

            set
            {
                this.url = value;
                this.RaisePropertyChanged("Url");
            }
        }

        /// <summary>
        /// Gets or sets the save command.
        /// </summary>
        public ICommand SaveCommand { get; set; }

        /// <summary>
        /// Initializes and prepares the data for viewmodel.
        /// </summary>
        public void Initialize()
        {
            var credentials = this.settingsManager.GetCredentials();
        }

        /// <summary>
        /// Called on save application settings.
        /// </summary>
        private void OnSave()
        {
        }
    }
}