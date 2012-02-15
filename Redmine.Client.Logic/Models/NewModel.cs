namespace Redmine.Client.Logic.Models
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// News model for data exchange with Redmine API.
    /// </summary>
    [XmlRoot("news")]
    public class NewsModel
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [XmlElement("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        [XmlElement("title")]
        public string Title { get; set; }
        
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [XmlElement("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        [XmlElement("created_on")]
        public DateTime CreatedOn { get; set; }
    }
}