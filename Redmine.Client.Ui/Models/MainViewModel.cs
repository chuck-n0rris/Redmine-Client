namespace Redmine.Client.Ui.Models
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using GalaSoft.MvvmLight.Command;
    
    using Redmine.Client.Logic.Domain;
    using Redmine.Client.Logic.Services;
    using Redmine.Client.Ui.Common;
    using Redmine.Client.Ui.Mvvm;

    /// <summary>
    /// View model for the projects view.
    /// </summary>
    public class MainViewModel : NotifyingModelBase, IPageViewModel
    {
        private readonly IProjectsService projectsService;
        private readonly INavigationService navigationService;

        private readonly INewsService newsService;

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
            
            this.Projects = new ObservableCollection<Project>();
            this.News = new ObservableCollection<News>();

            this.projectsService = projectsService;
            this.navigationService = navigationService;
            this.newsService = newsService;
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
        /// Gets or sets the Projects.
        /// </summary>
        public ObservableCollection<Project> Projects
        {
            get { return this.GetValue(it => it.Projects); }
            set { this.SetValueAndRaisePropertyChanged(it => it.Projects, value); }
        }

        /// <summary>
        /// Gets or sets the News.
        /// </summary>
        public ObservableCollection<News> News
        {
            get { return this.GetValue(it => it.News); }
            set { this.SetValueAndRaisePropertyChanged(it => it.News, value); }
        }

        /// <summary>
        /// Initializes the view model.
        /// </summary>
        /// <param name="parameter">
        /// The navigation parameter.
        /// </param>
        public void Initialize(object parameter)
        {
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
                this.navigationService.NavigateTo(PageNames.ProjectDetails, proj.Id));
        }
    }
}