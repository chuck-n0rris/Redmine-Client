namespace Redmine.Client.Logic.Domain
{
    using System.Collections.Generic;

    /// <summary>
    /// Describes the redmine issue.
    /// </summary>
    public class Issue
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the tracker.
        /// </summary>
        public Tracker Tracker { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the journals.
        /// </summary>
        public IEnumerable<Journal> Journals { get; set; }
    }
}