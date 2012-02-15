namespace Redmine.Client.Logic.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Redmine.Client.Logic.Domain;

    /// <summary>
    /// Provides news from the server.
    /// </summary>
    public interface INewsService
    {
        /// <summary>
        /// Gets form the server all news.
        /// </summary>
        /// <returns>
        /// Enumeration of news instances.
        /// </returns>
        Task<IEnumerable<News>> GetAll();
    }
}