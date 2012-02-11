namespace Redmine.Client.Ui.Common
{
    /// <summary>
    ///  Manages the application settings.
    /// </summary>
    public interface IApplicationSettingsManager
    {
        /// <summary>
        /// Gets Redmine client credentials class.
        /// </summary>
        /// <returns>
        /// The instance of <see cref="ConnectionSettings"/>
        /// </returns>
        ConnectionSettings GetConnectionSettings();
        
        /// <summary>
        /// Sets the application network credentials.
        /// </summary>
        /// <param name="credentials">
        /// The credentials.
        /// </param>
        void SetConnectionSettings(ConnectionSettings credentials);
    }
}