namespace Redmine.Client.Logic.Models
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// The issue jurnal.
    /// </summary>
    [XmlRoot("journal")]
    public class JournalModel
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [XmlAttribute("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        [XmlElement("user")]
        public ReferenceModel User { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        [XmlElement("notes")]
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        [XmlElement("created")]
        public DateTime Created { get; set; }
    }
}