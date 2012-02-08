namespace Redmine.Client.Logic.Services
{
    using System;
    using System.Net;
    
    /// <summary>
    /// The base class for all services.
    /// </summary>
    public class ServiceClent
    {
        private readonly RedmineCredentials credentials;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceClent"/> class.
        /// </summary>
        /// <param name="credentials">
        /// Authentication credentials.
        /// </param>
        protected ServiceClent(RedmineCredentials credentials)
        {
            this.credentials = credentials;
        }

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
            var webClient = new WebClient 
            { 
                Credentials = new NetworkCredential
                {
                    UserName = this.credentials.Login,
                    Password = this.credentials.Password
                }
            };

            webClient.DownloadStringAsync(new Uri(string.Format(@"{0}/{1}", credentials.Url, urlFragment)));
            webClient.DownloadStringCompleted += (sender, args) =>
            {
                var value = Serializer.Deserialize<T>(args.Result);
                callback(value);
            };
        }
    }
}