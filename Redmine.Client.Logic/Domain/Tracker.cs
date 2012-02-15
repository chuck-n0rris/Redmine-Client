﻿namespace Redmine.Client.Logic.Domain
{
    /// <summary>
    /// Describes the redmine issue tracker.
    /// </summary>
    public class Tracker
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }
    }
}