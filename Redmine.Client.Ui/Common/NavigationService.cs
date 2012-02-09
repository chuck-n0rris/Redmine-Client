namespace Redmine.Client.Ui.Common
{
    using System;
    using System.Windows;
    using System.Windows.Navigation;

    using Autofac;

    using Microsoft.Phone.Controls;

    using Redmine.Client.Logic.Domain;
    using Redmine.Client.Ui.Models;
    using Redmine.Client.Ui.Pages;

    /// <summary>
    /// Provides navigations by pages in application. 
    /// Also stores the journal of navigated pages that make posibility to go back to previous page.
    /// </summary>
    public class NavigationService : INavigationService
    {
        private readonly IContainer container;
        private PhoneApplicationFrame rootFrame;

        private object navigationParameter;
        private bool isNavigating;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        /// <param name="container">Ioc container.</param>
        public NavigationService(IContainer container)
        {
            this.container = container;
            this.isNavigating = false;

            Initialize();
        }

        /// <summary>
        /// Navigates to previous page.
        /// </summary>
        public void GoBack()
        {
        }

        /// <summary>
        /// Navigates to specified page.
        /// </summary>
        /// <param name="page">The name of the page.</param>
        public void NavigateTo(string page)
        {
            NavigateTo(page, null);
        }

        /// <summary>
        /// Navigates to specified page with parameter.
        /// </summary>
        /// <param name="page">The name of the page.</param>
        /// <param name="parameter">The navigation parameter.</param>
        public void NavigateTo(string page, object parameter)
        {
            if (isNavigating)
                throw new Exception("Previous navigation is in process.");

            this.isNavigating = true;
            var stringUrl = string.Format("/Pages/{0}.xaml", page);

            // sets the navigation parameter
            this.navigationParameter = parameter;
            this.rootFrame.Navigate(new Uri(stringUrl, UriKind.Relative));
        }

        /// <summary>
        /// Occurs when the content that is being navigated to has been found and is available.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="NavigationEventArgs"/> instance containing the event data.</param>
        private void OnNavigated(object sender, NavigationEventArgs e)
        {
            this.isNavigating = false;

            var element = (FrameworkElement)e.Content;
            if (element is Main)
            {
                var model = this.container.Resolve<MainViewModel>();
                element.DataContext = model;
            }

            if (element is ProjectDetails)
            {
                var model = this.container.Resolve<ProjectDetailsViewModel>();
                model.Initialize((Project)navigationParameter);
                element.DataContext = model;
            }

            if (element is Settings)
            {
                var model = this.container.Resolve<SettingsViewModel>();
                model.Initialize();
                element.DataContext = model;
            }
        }

        /// <summary>
        /// Occurs when an arror encountered while navigating to the requested content.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="NavigationFailedEventArgs"/> instance containing the event data.</param>
        private void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            this.isNavigating = false;
        }

        /// <summary>
        /// Initializes the navigation service instance and sets the main application page.
        /// </summary>
        private void Initialize()
        {
            rootFrame = new TransitionFrame();
            rootFrame.Navigated += OnNavigated;
            rootFrame.NavigationFailed += OnNavigationFailed;

            Application.Current.RootVisual = rootFrame;
        }
    }
}