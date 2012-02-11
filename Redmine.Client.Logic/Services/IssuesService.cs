namespace Redmine.Client.Logic.Services
{
    using System;
    using System.Reactive.Subjects;

    using Redmine.Client.Logic.Domain;
    using Redmine.Client.Logic.Extensions;
    using Redmine.Client.Logic.Models;

    /// <summary>
    /// Provides operation for manipulation with issues entityes.
    /// </summary>
    public class IssuesService : ServiceClent, IIssuesService
    {
        private Subject<Issue> issuesList;
        
        /// <summary>
        /// Gets the issues asynchronously
        /// </summary>
        /// <param name="projectId">The project id.</param>
        /// <returns>
        /// The observable issyes.
        /// </returns>
        public IObservable<Issue> Get(int projectId)
        {
            this.issuesList = new Subject<Issue>();
            
            var request = string.Format(@"issues.xml?project_id={0}&limit=100", projectId);
            this.HttpGet<IssuesListModel>(request, result =>
            {
                foreach (var issueModel in result.Issues)
                {
                    this.issuesList.OnNext(issueModel.ToIssue());
                }

                this.issuesList.OnCompleted();
                this.issuesList.Dispose();
            });

            return this.issuesList;
        }
    }
}