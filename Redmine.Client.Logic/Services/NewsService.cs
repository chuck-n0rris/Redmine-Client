namespace Redmine.Client.Logic.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Redmine.Client.Logic.Domain;
    using Redmine.Client.Logic.Extensions;
    using Redmine.Client.Logic.Models;

    /// <summary>
    /// Provides news from the server.
    /// </summary>
    public class NewsService : ServiceClent, INewsService
    {
        /// <summary>
        /// Gets form the server all news.
        /// </summary>
        /// <returns>
        /// Enumeration of news instances.
        /// </returns>
        public Task<IEnumerable<News>> GetAll()
        {
            var task = this.HttpGet<NewsListModel>("news.xml")
                .ContinueWith<IEnumerable<News>>(it =>
                {
                    var newsList = it.Result.News.Select(news => news.ToNews()).ToList();
                    return newsList;
                });

            return task;
        }
    }
}