namespace Redmine.Client.Logic.Models
{
    using System.Xml.Serialization;

    /// <summary>
    /// Projects list model for data exchange with Redmine API.
    /// </summary>
    [XmlRoot("projects")]
    public class ProjectsListModel
    {
        /// <summary>
        /// Gets or sets the projects.
        /// </summary>
        [XmlElement("project")]
        public ProjectModel[] Projects { get; set; }

        /// <summary>
        /// Gets or sets the total count.
        /// </summary>
        [XmlAttribute("total_count")]
        public string TotalCount { get; set; }

        /// <summary>
        /// Gets or sets the limit.
        /// </summary>
        [XmlAttribute("limit")]
        public string Limit { get; set; }

        /// <summary>
        /// Gets or sets the offset.
        /// </summary>
        [XmlAttribute("offset")]
        public string Offset { get; set; }
    }
}