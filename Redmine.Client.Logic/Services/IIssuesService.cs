namespace Redmine.Client.Logic.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Redmine.Client.Logic.Domain;

    /// <summary>
    /// Provides operation for manipulation with issues entityes.
    /// </summary>
    public interface IIssuesService
    {
        /// <summary>
        /// Gets the issues asynchronously.
        /// </summary>
        /// <param name="projectId">The project id.</param>
        /// <returns>
        /// The task.
        /// </returns>
        Task<IEnumerable<Issue>> GetProjectIssues(int projectId);

        /// <summary>
        /// Gets the issue by identifier.
        /// </summary>
        /// <param name="issueId">The issue identifier.</param>
        /// <returns>
        /// The task.
        /// </returns>
        Task<Issue> GetIssue(int issueId);
    }
}