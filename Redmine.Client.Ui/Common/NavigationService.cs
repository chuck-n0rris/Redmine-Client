namespace Redmine.Client.Ui.Common
{
    using System;
    using System.Windows;
    using System.Windows.Navigation;

    using Autofac;

    using Microsoft.Phone.Controls;

    using Redmine.Client.Ui.Mvvm;
    
    /// <summary>
    /// Provides navigations by pages in application. 
    /// Also stores the journal of navigated pages that make posibility to go back to previous page.
    /// </summary>
    public class NavigationService : INavigationService
    {
        private readonly IContainer container;
        
        private PhoneApplicationFrame rootFrame;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        /// <param name="container">Ioc container.</param>
        public NavigationService(IContainer container)
        {
            this.container = container;
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
        /// <param name="page">
        /// The name of the page to navigate.
        /// </param>
        /// <param name="parameter">
        /// The navigation parameter.
        /// </param>
        public void NavigateTo(string page, object parameter)
        {
            var stringUrl = string.Format("/Pages/{0}.xaml", page);

            // adds query string to url if navigation has parameter.
            if (parameter != null)
            {
                stringUrl = stringUrl + "?param=" + parameter;
            }

            this.rootFrame.Navigate(new Uri(stringUrl, UriKind.Relative));
        }

        /// <summary>
        /// Occurs when the content that is being navigated to has been found and is available.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="NavigationEventArgs"/> instance containing the event data.</param>
        private void OnNavigated(object sender, NavigationEventArgs e)
        {
            var pageName = e.Uri.ExtractPageName();
            var parameters = e.Uri.ExtractParameters();
            
            var viewModel = this.container.ResolveNamed<IPageViewModel>(pageName);
            var content = (FrameworkElement)e.Content;
            content.DataContext = viewModel;

            if (parameters.Count > 0)
            {
                viewModel.Initialize(parameters["param"]);
                return;
            }
            
            viewModel.Initialize(null);
        }

        /// <summary>
        /// Occurs when an arror encountered while navigating to the requested content.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">
        /// The <see cref="NavigationFailedEventArgs"/> instance containing the event data.
        /// </param>
        private void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
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