namespace Redmine.Client.Logic.Models
{
    using System.Xml.Serialization;

    /// <summary>
    /// Issues list model for data exchange with Redmine API.
    /// </summary>
    [XmlRoot("issues")]
    public class IssuesListModel
    {
        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        [XmlAttribute("count")]
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the issues.
        /// </summary>
        [XmlElement("issue")]
        public IssueModel[] Issues { get; set; }
    }
}