namespace Redmine.Client.Logic.Services
{
    using System;
    using System.Reactive.Subjects;

    using Redmine.Client.Logic.Domain;
    using Redmine.Client.Logic.Extensions;
    using Redmine.Client.Logic.Models;

    /// <summary>
    /// Provides manipulations with projects.
    /// </summary>
    public class ProjectsService : ServiceClent, IProjectsService
    {
        private Subject<Project> projectsList;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceClent"/> class.
        /// </summary>
        /// <param name="credentials">
        /// Authentication credentials.
        /// </param>
        public ProjectsService(RedmineCredentials credentials)
            : base(credentials)
        {
        }

        /// <summary>
        /// Gets the collection of projects.
        /// </summary>
        /// <returns>The list of projects.</returns>
        public IObservable<Project> Get()
        {
            this.projectsList = new Subject<Project>();

            this.HttpGet<ProjectsListModel>("projects.xml", result =>
            {
                foreach (var projectModel in result.Projects)
                {
                    this.projectsList.OnNext(projectModel.ToProject());
                }

                this.projectsList.OnCompleted();
                this.projectsList.Dispose();
            });
            
            return this.projectsList;
        }
    }
}