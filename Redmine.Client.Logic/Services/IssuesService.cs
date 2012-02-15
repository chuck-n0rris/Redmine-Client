namespace Redmine.Client.Logic.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Redmine.Client.Logic.Domain;
    using Redmine.Client.Logic.Extensions;
    using Redmine.Client.Logic.Models;

    /// <summary>
    /// Provides operation for manipulation with issues entityes.
    /// </summary>
    public class IssuesService : ServiceClent, IIssuesService
    {
        /// <summary>
        /// Gets the issues asynchronously
        /// </summary>
        /// <param name="projectId">The project id.</param>
        /// <returns>
        /// The observable issyes.
        /// </returns>
        public Task<IEnumerable<Issue>> Get(int projectId)
        {
            var request = string.Format(@"issues.xml?project_id={0}&limit=25", projectId);

            var task = this.HttpGet<IssuesListModel>(request)
                .ContinueWith<IEnumerable<Issue>>(it =>
                    {
                        var issuesList = it.Result.Issues.Select(issue => issue.ToIssue()).ToList();
                        return issuesList;
                    });

            return task;
        }
    }
}