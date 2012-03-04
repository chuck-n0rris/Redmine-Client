namespace Redmine.Client.Logic.Extensions
{
    using System.Linq;

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
                Description = model.Description,
                Tracker = new Tracker { Id = model.Tracker.Id, Name = model.Tracker.Name }
            };

            if (model.Journals != null && model.Journals.Journals != null)
            {
                issue.Journals = model.Journals.Journals
                    .Select(it => it.ToJournal())
                    .ToList();
            }

            return issue;
        }

        /// <summary>
        /// Converts from <see cref="JournalModel"/> to <see cref="Journal"/> object.
        /// </summary>
        /// <param name="model">The data access model.</param>
        /// <returns>
        /// The instance of <see cref="Issue"/> entity.
        /// </returns>
        public static Journal ToJournal(this JournalModel model)
        {
            var journal = new Journal();
            journal.Id = model.Id;
            journal.Notes = model.Notes;
            journal.Created = model.Created;
            journal.User = new Reference { Id = model.User.Id, Name = model.User.Name };

            return journal;
        }

        /// <summary>
        /// Converts from <see cref="NewsModel"/> to <see cref="News"/> object.
        /// </summary>
        /// <param name="model">The data access model.</param>
        /// <returns>
        /// The instance of <see cref="News"/> entity.
        /// </returns>
        public static News ToNews(this NewsModel model)
        {
            var news = new News
            {
                Id = model.Id,
                Title  = model.Title,
                Description = model.Description,
                CreatedOn = model.CreatedOn
            };

            return news;
        }
    }
}