namespace Redmine.Client.Ui.Models
{
    using System.Collections.Generic;
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

        private readonly INewsService newsService;

        private ObservableCollection<Project> projects;
        private ObservableCollection<News> news;

        /// <summary>
        /// Initializes a new instance of the ViewModelBase class.
        /// </summary>
        /// <param name="projectsService">
        /// Provides manipulations with projects entities.
        /// </param>
        /// <param name="navigationService">
        /// Provides navigations by pages in application. 
        /// </param>
        /// <param name="newsService">
        /// Provides news from the server.
        /// </param>
        public MainViewModel(IProjectsService projectsService, 
                             INavigationService navigationService,
                             INewsService newsService)
        {
            this.InitializeCommands();

            this.projects = new ObservableCollection<Project>();
            this.news = new ObservableCollection<News>();

            this.projectsService = projectsService;
            this.navigationService = navigationService;
            this.newsService = newsService;

            this.projectsService.Get()
                .ContinueWith(it => UiThread.Dispatch(() =>
                    {
                        foreach (var project in it.Result)
                        {
                            this.Projects.Add(project);
                        }
                    }));

            this.newsService.GetAll().ContinueWith(it => UiThread.Dispatch(() => OnNewsReceived(it.Result)));
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
        /// Gets or sets the projects.
        /// </summary>
        public ObservableCollection<News> News
        {
            get
            {
                return this.news;
            }

            set
            {
                this.news = value;
                this.RaisePropertyChanged("News");
            }
        }

        /// <summary>
        /// Called when news received.
        /// </summary>
        /// <param name="newsList">
        /// The enumeration of news.
        /// </param>
        private void OnNewsReceived(IEnumerable<News> newsList)
        {
            foreach (var item in newsList)
            {
                this.News.Add(item);
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