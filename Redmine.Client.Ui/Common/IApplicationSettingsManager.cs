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
        /// The instance of <see cref="ClientCredentials"/>
        /// </returns>
        ClientCredentials GetCredentials();
    }
}