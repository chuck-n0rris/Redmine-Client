namespace Redmine.Client.Logic.Domain
{
    /// <summary>
    /// This is an reference to the entity with properties name and id.
    /// </summary>
    public class Reference
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