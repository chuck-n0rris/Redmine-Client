namespace Redmine.Client.Logic.Models
{
    using System.Xml.Serialization;

    /// <summary>
    /// This is an reference to the entity with properties name and id.
    /// </summary>
    [XmlRoot]
    public class ReferenceModel
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [XmlAttribute("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [XmlAttribute("name")]
        public string Name { get; set; }
    }
}