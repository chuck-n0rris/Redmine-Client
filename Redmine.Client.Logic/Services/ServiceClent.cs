namespace Redmine.Client.Logic.Services
{
    using System;
    using System.IO;
    using System.Net;
    using System.Threading.Tasks;

    using Redmine.Client.Logic.Models;

    /// <summary>
    /// The base class for all services.
    /// </summary>
    public class ServiceClent
    {
        /// <summary>
        /// Send the GET request to the server.
        /// </summary>
        /// <typeparam name="T">The result type.</typeparam>
        /// <param name="urlFragment">
        /// The URL fragemnt which identify the operation.
        /// </param>
        /// <returns>The task with responce.</returns>
        protected Task<T> HttpGet<T>(string urlFragment) where T : new()
        {
             var request = WebRequest.Create(new Uri(string.Format(@"{0}/{1}", ServiceSettings.Url, urlFragment)));
            
            if (ServiceSettings.AuthenticationRequired)
            {
                request.Credentials = new NetworkCredential
                    {
                        UserName = ServiceSettings.Login, 
                        Password = ServiceSettings.Password
                    };
            }

            var task = Task.Factory
                .FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, this)
                .ContinueWith<T>(it =>
                {
                    var response = (HttpWebResponse)it.Result;
                    var stream = response.GetResponseStream();

                    var streamReader = new StreamReader(stream);
                    var responce = streamReader.ReadToEnd();
                    
                    // TODO: Need to solve this trash :)
                    if (typeof(T) == typeof(NewsListModel))
                    {
                        var index = responce.IndexOf("news", 0);
                        responce = responce.Remove(index, 4).Insert(index, "news1");

                        index = responce.LastIndexOf("news");
                        responce = responce.Remove(index, 4).Insert(index, "news1");
                    }

                    var value = Serializer.Deserialize<T>(responce);
                    return value;
                });
            
            return task;
        }
    }
}