namespace Redmine.Client.Logic.Services
{
    using System;
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
        /// The observable issyes.
        /// </returns>
        Task<IEnumerable<Issue>> Get(int projectId);
    }
}