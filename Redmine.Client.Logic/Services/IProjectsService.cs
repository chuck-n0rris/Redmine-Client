namespace Redmine.Client.Logic.Services
{
    using System;

    using Redmine.Client.Logic.Domain;

    /// <summary>
    /// Provides manipulations with projects entities.
    /// </summary>
    public interface IProjectsService
    {
        /// <summary>
        /// Gets the collection of projects.
        /// </summary>
        /// <returns>The list of projects.</returns>
        IObservable<Project> Get();
    }
}