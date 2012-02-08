namespace Redmine.Client.Ui
{
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
        
        /// <summary>
        /// Runs this application.
        /// </summary>
        public void Run()
        {
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
            builder.RegisterType<ApplicationSettingsManager>()
                   .As<IApplicationSettingsManager>()
                   .SingleInstance();

            builder.RegisterType<NavigationService>()
                   .As<INavigationService>()
                   .SingleInstance();

            builder.RegisterType<ProjectsService>()
                   .As<IProjectsService>()
                   .WithParameters(new[]
                       {
                           new TypedParameter(typeof(RedmineCredentials), 
                               new RedmineCredentials { Url = "http://redmine.binary-studio.org", 
                                   Login = "denisk", Password = "denisk" } ), 
                       });
                   

            builder.RegisterType<IssuesService>()
                   .As<IIssuesService>()
                   .WithParameters(new[]
                       {
                           new TypedParameter(typeof(RedmineCredentials), new RedmineCredentials
                               {
                                   Url = "http://redmine.binary-studio.org", 
                                   Login = "denisk", 
                                   Password = "denisk" 
                               } )
                       });

            // register view models
            builder.RegisterType<MainViewModel>();
            builder.RegisterType<ProjectDetailsViewModel>();
            builder.RegisterType<SettingsViewModel>();
        }
    }
}