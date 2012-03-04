namespace Redmine.Client.Ui.Models
{
    using System;

    using Redmine.Client.Logic.Services;
    using Redmine.Client.Ui.Common;
    using Redmine.Client.Ui.Mvvm;

    /// <summary>
    /// View model for the <see cref="Redmine.Client.Ui.Pages.IssueDetails"/> view.
    /// </summary>
    public class IssueDetailsViewModel : NotifyingModelBase, IPageViewModel
    {
        private readonly INavigationService navigationService;
        private readonly IIssuesService issuesService;

        /// <summary>
        /// Initializes a new instance of the <see cref="IssueDetailsViewModel"/> class.
        /// </summary>
        /// <param name="navigationService">
        /// Provides navigations by pages in application.
        /// </param>
        /// <param name="issuesService">The issues service.</param>
        public IssueDetailsViewModel(INavigationService navigationService, 
                                     IIssuesService issuesService)
        {
            this.navigationService = navigationService;
            this.issuesService = issuesService;
        }

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        public string Title
        {
            get { return this.GetValue(it => it.Title); }
            set { this.SetValueAndRaisePropertyChanged(it => it.Title, value); }
        }

        /// <summary>
        /// Gets or sets the Subject.
        /// </summary>
        public string Subject
        {
            get { return this.GetValue(it => it.Subject); }
            set { this.SetValueAndRaisePropertyChanged(it => it.Subject, value); }
        }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        public string Description
        {
            get { return this.GetValue(it => it.Description); }
            set { this.SetValueAndRaisePropertyChanged(it => it.Description, value); }
        }

        /// <summary>
        /// Initializes the view model.
        /// </summary>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        public void Initialize(object parameter)
        {
            var issueId = Convert.ToInt32(parameter);

            this.issuesService.GetIssue(issueId)
                .ContinueWith(it => UiThread.Dispatch(() =>
                {
                    this.Title = string.Format("issue #{0}", issueId);
                    this.Subject = it.Result.Subject;
                    this.Description = it.Result.Description;
                }));
        }
    }
}