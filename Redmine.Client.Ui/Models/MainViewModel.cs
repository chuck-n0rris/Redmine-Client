namespace Redmine.Client.Ui.Models
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    
    using Redmine.Client.Logic.Domain;
    using Redmine.Client.Logic.Services;
    using Redmine.Client.Ui.Common;
    
    /// <summary>
    /// View model for the projects view.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IProjectsService projectsService;
        private readonly INavigationService navigationService;

        private ObservableCollection<Project> projects;

        /// <summary>
        /// Initializes a new instance of the ViewModelBase class.
        /// </summary>
        /// <param name="projectsService">
        /// Provides manipulations with projects entities.
        /// </param>
        /// <param name="navigationService">
        /// Provides navigations by pages in application. 
        /// </param>
        public MainViewModel(IProjectsService projectsService, INavigationService navigationService)
        {
            this.InitializeCommands();

            this.projects = new ObservableCollection<Project>();

            this.projectsService = projectsService;
            this.navigationService = navigationService;
            this.projectsService.Get().Subscribe(proj => UiThread.Dispatch(() => this.projects.Add(proj)));
        }

        /// <summary>
        /// Gets the settings command.
        /// </summary>
        public ICommand SettingsCommand { get; set; }

        /// <summary>
        /// Gets or sets the select project command.
        /// </summary>
        public ICommand SelectProjectCommand { get; set; }

        /// <summary>
        /// Gets or sets the projects.
        /// </summary>
        public ObservableCollection<Project> Projects
        {
            get
            {
                return this.projects;
            }

            set
            {
                this.projects = value;
                this.RaisePropertyChanged("Projects");
            }
        }

        /// <summary>
        /// Initializes the commands.
        /// </summary>
        private void InitializeCommands()
        {
            this.SettingsCommand = new RelayCommand(() =>
                this.navigationService.NavigateTo(PageNames.Settings));

            this.SelectProjectCommand = new RelayCommand<Project>(proj =>
                this.navigationService.NavigateTo(PageNames.ProjectDetails, proj));
        }
    }
}