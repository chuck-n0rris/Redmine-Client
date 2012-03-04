namespace Redmine.Client.Ui.Models
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using GalaSoft.MvvmLight.Command;

    using Redmine.Client.Logic.Domain;
    using Redmine.Client.Logic.Services;
    using Redmine.Client.Ui.Common;
    using Redmine.Client.Ui.Mvvm;
    using Redmine.Client.Ui.Pages;

    /// <summary>
    /// View model for <see cref="ProjectDetails"/> view.
    /// </summary>
    public class ProjectDetailsViewModel : NotificationObject, IPageViewModel
    {
        private readonly IIssuesService issuesService;
        private readonly INavigationService navigationService;

        private ObservableCollection<IssueViewModel> issues;

        /// <summary>
        /// Initializes a new instance of the ViewModelBase class.
        /// </summary>
        /// <param name="issuesService">
        /// The issues service.
        /// </param>
        /// <param name="navigationService">
        /// Provides navigations by pages in application. 
        /// </param>
        public ProjectDetailsViewModel(IIssuesService issuesService, INavigationService navigationService)
        {
            this.issuesService = issuesService;
            this.navigationService = navigationService;
            this.issues = new ObservableCollection<IssueViewModel>();

            this.SelectIssueCommand = new RelayCommand<IssueViewModel>(OnIssueSelect);
        }

        /// <summary>
        /// Gets or sets the projects.
        /// </summary>
        public ObservableCollection<IssueViewModel> Issues
        {
            get
            {
                return this.issues;
            }

            set
            {
                this.issues = value;
                this.RaisePropertyChanged(() => Issues);
            }
        }
        
        /// <summary>
        /// Gets or sets the select issue command.
        /// </summary>
        public ICommand SelectIssueCommand { get; set; }

        /// <summary>
        /// Initializes the view model.
        /// </summary>
        /// <param name="param">
        /// The initalization parameter.
        /// </param>
        public void Initialize(object param)
        {
            var projectId = Convert.ToInt32(param);

            this.issuesService.GetProjectIssues(projectId)
                .ContinueWith(it => UiThread.Dispatch(() =>
                {
                    foreach (var issue in it.Result)
                    {
                        this.Issues.Add(new IssueViewModel(issue));
                    }
                }));
        }

        /// <summary>
        /// Called when issue was selected.
        /// </summary>
        /// <param name="issue">The issue view model.</param>
        private void OnIssueSelect(IssueViewModel issue)
        {
            this.navigationService.NavigateTo(PageNames.IssueDetails, issue.Source.Id);
        }
    }
}