namespace Redmine.Client.Logic.Services
{
    using System;
    using System.Net;
    
    /// <summary>
    /// The base class for all services.
    /// </summary>
    public class ServiceClent
    {
        /// <summary>
        /// Gets or sets the connection settings.
        /// </summary>
        /// <value>
        /// The connection settings.
        /// </value>
        public RedmineConnectionSettings ConnectionSettings { get; set; }

        /// <summary>
        /// Send the GET request to the server.
        /// </summary>
        /// <typeparam name="T">The result type.</typeparam>
        /// <param name="urlFragment">
        /// The URL fragemnt which identify the operation.
        /// </param>
        /// <param name="callback">
        /// The callback action which will called when download operaton completed.
        /// </param>
        protected void HttpGet<T>(string urlFragment, Action<T> callback)
        {
            var webClient = new WebClient();
            if (this.ConnectionSettings.AuthenticationRequired)
            {
                webClient.Credentials = new NetworkCredential
                {
                    UserName = this.ConnectionSettings.Login,
                    Password = this.ConnectionSettings.Password
                };
            }

            webClient.DownloadStringAsync(new Uri(string.Format(@"{0}/{1}", this.ConnectionSettings.Url, urlFragment)));
            webClient.DownloadStringCompleted += (sender, args) =>
            {
                if (args.Error != null) 
                    throw args.Error;

                var value = Serializer.Deserialize<T>(args.Result);
                callback(value);
            };
        }
    }
}