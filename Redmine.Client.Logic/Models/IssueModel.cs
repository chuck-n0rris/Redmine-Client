namespace Redmine.Client.Logic.Models
{
    using System.Xml.Serialization;

    /// <summary>
    /// Issue model for data exchange with Redmine API.
    /// </summary>
    [XmlRoot("issue")]
    public class IssueModel
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [XmlElement("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the tracker.
        /// </summary>
        [XmlElement("tracker")]
        public ReferenceModel Tracker { get; set; }

        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        [XmlElement("subject")]
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [XmlElement("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the journals.
        /// </summary>
        [XmlElement("journals")]
        public JournalListModel Journals { get; set; }
    }
}