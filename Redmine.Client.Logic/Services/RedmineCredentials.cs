namespace Redmine.Client.Logic.Services
{
    /// <summary>
    /// Authentication credentials for Redmine API.
    /// </summary>
    public class RedmineCredentials
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        public string Url { get; set; }
    }
}