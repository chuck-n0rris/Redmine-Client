namespace Redmine.Client.Ui.Common
{
    /// <summary>
    /// Contains fields for login to the redmine client.
    /// </summary>
    public class ClientCredentials
    {
        /// <summary>
        /// Gets or sets the login.
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