namespace Redmine.Client.Logic.Services
{
    /// <summary>
    /// Contains global setting for all services.
    /// </summary>
    public class ServiceSettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether authentication required.
        /// </summary>
        public static bool AuthenticationRequired { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public static string Login { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public static string Password { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        public static string Url { get; set; }
    }
}