namespace Redmine.Client.Ui
{
    using Autofac;
    using Autofac.Core;
    
    using Redmine.Client.Logic.Services;
    using Redmine.Client.Ui.Common;
    using Redmine.Client.Ui.Models;
    using Redmine.Client.Ui.Mvvm;

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
            
            InitializeConnectionSettings();
            RegisterTypes(builder);
            
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
            builder.RegisterInstance(applicationSettings).As<IApplicationSettingsManager>().SingleInstance();
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            builder.RegisterType<UiMessagesService>().As<IMessagesService>().SingleInstance();

            builder.RegisterType<ProjectsService>().As<IProjectsService>();
            builder.RegisterType<IssuesService>().As<IIssuesService>();
            builder.RegisterType<PingService>().As<IPingService>();
            builder.RegisterType<NewsService>().As<INewsService>();

            // register view models
            builder.RegisterType<MainViewModel>().Named<IPageViewModel>(PageNames.Main);
            builder.RegisterType<ProjectDetailsViewModel>().Named<IPageViewModel>(PageNames.ProjectDetails);
            builder.RegisterType<SettingsViewModel>().Named<IPageViewModel>(PageNames.Settings);
            builder.RegisterType<IssueDetailsViewModel>().Named<IPageViewModel>(PageNames.IssueDetails);
        }

        /// <summary>
        /// Initializes the connection settings.
        /// </summary>
        private void InitializeConnectionSettings()
        {
            var settings = applicationSettings.GetConnectionSettings();
            
            ServiceSettings.AuthenticationRequired = settings.AuthenticationRequired;
            ServiceSettings.Login = settings.Login;
            ServiceSettings.Password = settings.Password;
            ServiceSettings.Url = settings.Url;
        }
    }
}