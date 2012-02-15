namespace Redmine.Client.Logic.Models
{
    using System.Xml.Serialization;

    /// <summary>
    /// News list model for data exchange with Redmine API.
    /// </summary>
    [XmlRoot("news1")]
    public class NewsListModel
    {
        /// <summary>
        /// Gets or sets the issues.
        /// </summary>
        [XmlElement("news")]
        public NewsModel[] News { get; set; }
    }
}