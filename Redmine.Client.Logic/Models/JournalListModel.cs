namespace Redmine.Client.Logic.Models
{
    using System.Collections.Generic;
    using System.Xml.Serialization;
    
    /// <summary>
    /// THe journals list model.
    /// </summary>
    [XmlRoot]
    public class JournalListModel
    {
        /// <summary>
        /// Gets or sets the journals.
        /// </summary>
        [XmlElement("journal")]
        public List<JournalModel> Journals { get; set; }
    }
}