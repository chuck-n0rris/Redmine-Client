namespace Redmine.Client.Logic.Extensions
{
    using Redmine.Client.Logic.Domain;
    using Redmine.Client.Logic.Models;

    /// <summary>
    /// Converting from data access layer objects to domain.
    /// </summary>
    public static class ConvertExtensions
    {
        /// <summary>
        /// Converts from <see cref="ProjectModel"/> to <see cref="Project"/> object.
        /// </summary>
        /// <param name="model">The data access model.</param>
        /// <returns>
        /// The instance of <see cref="Project"/> entity.
        /// </returns>
        public static Project ToProject(this ProjectModel model)
        {
            var project = new Project
            {
                Id = model.Id,
                Name = model.Name,
                Identifier = model.Identifier,
                Description = model.Description,
                CreatedOn = model.CreatedOn,
                UpdatedOn = model.UpdatedOn
            };

            return project;
        }

        /// <summary>
        /// Converts from <see cref="IssueModel"/> to <see cref="Issue"/> object.
        /// </summary>
        /// <param name="model">The data access model.</param>
        /// <returns>
        /// The instance of <see cref="Issue"/> entity.
        /// </returns>
        public static Issue ToIssue(this IssueModel model)
        {
            var issue = new Issue
            {
                Id = model.Id,
                Subject = model.Subject,
                Description = model.Description
            };

            return issue;
        }
    }
}