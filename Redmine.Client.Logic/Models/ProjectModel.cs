namespace Redmine.Client.Logic.Models
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// Project model for data exchange with Redmine API.
    /// </summary>
    [XmlRoot("project")]
    public class ProjectModel
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [XmlElement("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [XmlElement("identifier")]
        public string Identifier { get; set; }

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

        /// <summary>
        /// Gets or sets the updated on.
        /// </summary>
        [XmlElement("updated_on")]
        public DateTime UpdatedOn { get; set; }
    }
}