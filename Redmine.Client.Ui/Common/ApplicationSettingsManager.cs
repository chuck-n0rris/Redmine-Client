namespace Redmine.Client.Ui.Common
{
    using System.IO.IsolatedStorage;

    /// <summary>
    /// Manages the application settings.
    /// </summary>
    public class ApplicationSettingsManager : IApplicationSettingsManager
    {
        /// <summary>
        /// Gets Redmine client credentials class.
        /// </summary>
        /// <returns>
        /// The instance of <see cref="ClientCredentials"/>
        /// </returns>
        public ClientCredentials GetCredentials()
        {
            if (IsolatedStorageSettings.ApplicationSettings.Contains("RedmineClientCredentials"))
            {
                var storage = (ClientCredentials)IsolatedStorageSettings.ApplicationSettings["RedmineClientCredentials"];
                return storage;
            }

            return null;
        }

        /// <summary>
        /// Sets the application network credentials.
        /// </summary>
        /// <param name="credentials">
        /// The credentials.
        /// </param>
        public void SetCredentials(ClientCredentials credentials)
        {
            IsolatedStorageSettings.ApplicationSettings["RedmineClientCredentials"] = credentials;
        }
    }
}