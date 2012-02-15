namespace Redmine.Client.Ui.Common
{
    using System.Windows;

    /// <summary>
    /// This service provode manipulation with child winfows.
    /// </summary>
    public class UiMessagesService : IMessagesService
    {
        /// <summary>
        /// Shows message box with information message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Info(string message)
        {
            MessageBox.Show(message, "Info", MessageBoxButton.OK);
        }

        /// <summary>
        /// Shows child window with error message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Error(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButton.OK);
        }
    }
}