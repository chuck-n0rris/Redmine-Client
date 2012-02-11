namespace Redmine.Client.Ui
{
    using System.Collections.Generic;

    using Autofac;
    using Autofac.Core;
    
    using Redmine.Client.Logic.Services;
    using Redmine.Client.Ui.Common;
    using Redmine.Client.Ui.Models;

    /// <summary>
    /// Class which configure the Ioc conteiner and application settings.
    /// </summary>
    public class Bootstrapper
    {
        private IContainer container;
        private IApplicationSettingsManager applicationSettings;
        
        /// <summary>
        /// Runs this application.
        /// </summary>
        public void Run()
        {
            // initializes the application settings manager.
            this.applicationSettings = new ApplicationSettingsManager();

            var builder = new ContainerBuilder();
            this.RegisterTypes(builder);
            
            this.container = builder.Build();

            var navigation = this.container
                .Resolve<INavigationService>(new Parameter[] { new TypedParameter(typeof(IContainer), container) });

            navigation.NavigateTo(PageNames.Main);
        }

        /// <summary>
        /// Registers the container types.
        /// </summary>
        /// <param name="builder">The builder.</param>
        private void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterInstance(applicationSettings)
                   .As<IApplicationSettingsManager>()
                   .SingleInstance();
            
            builder.RegisterType<NavigationService>()
                   .As<INavigationService>()
                   .SingleInstance();

            builder.RegisterType<ProjectsService>()
                .As<IProjectsService>()
                .OnActivating(it => it.ReplaceInstance(new ProjectsService { ConnectionSettings = GetRedmineSettingsParameter() }));

            builder.RegisterType<IssuesService>()
                .As<IIssuesService>()
                .OnActivating(it => it.ReplaceInstance(new IssuesService { ConnectionSettings = GetRedmineSettingsParameter() }));

            // register view models
            builder.RegisterType<MainViewModel>();
            builder.RegisterType<ProjectDetailsViewModel>();
            builder.RegisterType<SettingsViewModel>();
        }

        /// <summary>
        /// Converts to redmine connection settings.
        /// </summary>
        /// <returns>
        /// Converted instance of <see cref="RedmineConnectionSettings"/> class.
        /// </returns>
        private RedmineConnectionSettings GetRedmineSettingsParameter()
        {
            var settings = applicationSettings.GetConnectionSettings();

            return new RedmineConnectionSettings
                    {
                        AuthenticationRequired = settings.AuthenticationRequired,
                        Login = settings.Login,
                        Password = settings.Password,
                        Url = settings.Url
                    };
        }
    }
}