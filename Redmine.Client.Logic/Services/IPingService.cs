namespace Redmine.Client.Logic.Services
{
    using System.Threading.Tasks;

    /// <summary>
    /// Provides methods to check connection. 
    /// </summary>
    public interface IPingService
    {
        /// <summary>
        /// Tests the connection to site.
        /// </summary>
        /// <returns>Task of connection result.</returns>
        Task<bool> TestConnection();
    }
}