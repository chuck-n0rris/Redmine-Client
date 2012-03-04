namespace Redmine.Client.Ui.Models
{
    using Redmine.Client.Logic.Domain;
    using Redmine.Client.Ui.Mvvm;

    /// <summary>
    /// View model which present the issue.
    /// </summary>
    public class IssueViewModel : NotificationObject
    {
        private string subject;
        private string description;
        private string tracker;

        /// <summary>
        /// Initializes a new instance of the <see cref="IssueViewModel"/> class.
        /// </summary>
        /// <param name="issue">
        /// The issue domain model.
        /// </param>
        public IssueViewModel(Issue issue)
        {
            this.Source = issue;

            this.Subject = this.Source.Subject;
            this.Description = this.Source.Description;
            this.Tracker = this.Source.Tracker.Name;
        }

        /// <summary>
        /// Gets the title name.
        /// </summary>
        public string Title
        {
            get
            {
                return string.Format("issue #{0}", this.Source.Id);
            }
        }
        
        /// <summary>
        /// Gets or sets the tracker.
        /// </summary>
        public string Tracker
        {
            get
            {
                return this.tracker;
            }

            set
            {
                this.tracker = value;
                this.RaisePropertyChanged(() => Tracker);
            }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Subject
        {
            get
            {
                return this.subject;
            }

            set
            {
                this.subject = value;
                this.RaisePropertyChanged(() => this.Subject);
            }
        }
        
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description
        {
            get
            {
                return this.description;
            }

            set
            {
                this.description = value;
                this.RaisePropertyChanged(() => Description);
            }
        }

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        public Issue Source { get; private set; }
    }
}