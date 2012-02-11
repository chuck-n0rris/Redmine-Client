namespace Redmine.Client.Logic.Services
{
    /// <summary>
    /// Authentication credentials for Redmine API.
    /// </summary>
    public class RedmineConnectionSettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether authentication required.
        /// </summary>
        public bool AuthenticationRequired { get; set; }

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