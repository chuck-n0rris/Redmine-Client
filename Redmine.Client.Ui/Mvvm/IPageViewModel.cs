namespace Redmine.Client.Ui.Mvvm
{
    /// <summary>
    /// Interface to be implemented by view model page with has parameters.
    /// </summary>
    public interface IPageViewModel
    {
        /// <summary>
        /// Initializes the view model.
        /// </summary>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        void Initialize(object parameter);
    }
}