namespace Redmine.Client.Ui.Common
{
    /// <summary>
    /// Provides navigations by pages in application. 
    /// Also stores the journal of navigated pages that make posibility to go back to previous page.
    /// </summary>
    public interface INavigationService
    {
        /// <summary>
        /// Navigates to previous page.
        /// </summary>
        void GoBack();

        /// <summary>
        /// Navigates to specified page.
        /// </summary>
        /// <param name="page">
        /// The name of the page.
        /// </param>
        void NavigateTo(string page);

        /// <summary>
        /// Navigates to specified page with parameter.
        /// </summary>
        /// <param name="page">The name of the page.</param>
        /// <param name="parameter">The navigation parameter.</param>
        void NavigateTo(string page, object parameter);
    }
}