namespace Redmine.Client.Logic.Services
{
    using System.Threading.Tasks;
    using Redmine.Client.Logic.Models;

    /// <summary>
    /// Provides methods to check connection. 
    /// </summary>
    public class PingService : ServiceClent, IPingService
    {
        /// <summary>
        /// Tests the connection to site.
        /// </summary>
        /// <returns>Task of connection result.</returns>
        public Task<bool> TestConnection()
        {
            var task = this.HttpGet<ProjectsListModel>("projects.xml")
                .ContinueWith<bool>(it => it.Result != null);

            return task;    
        }
    }
}