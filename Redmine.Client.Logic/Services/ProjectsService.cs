namespace Redmine.Client.Logic.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Redmine.Client.Logic.Domain;
    using Redmine.Client.Logic.Extensions;
    using Redmine.Client.Logic.Models;

    /// <summary>
    /// Provides manipulations with projects.
    /// </summary>
    public class ProjectsService : ServiceClent, IProjectsService
    {
        /// <summary>
        /// Gets the collection of projects.
        /// </summary>
        /// <returns>The list of projects.</returns>
        public Task<IEnumerable<Project>> Get()
        {
            var task = this.HttpGet<ProjectsListModel>("projects.xml")
                .ContinueWith<IEnumerable<Project>>(it =>
                    {
                        var projectList = it.Result.Projects
                            .Select(model => model.ToProject())
                            .ToList();

                        return projectList;
                    });

            return task;
        }
    }
}