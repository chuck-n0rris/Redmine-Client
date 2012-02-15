namespace Redmine.Client.Ui.Common
{
    /// <summary>
    /// This service provode manipulation with child winfows.
    /// </summary>
    public interface IMessagesService
    {
        /// <summary>
        /// Shows child window with information.
        /// </summary>
        /// <param name="message">The message.</param>
        void Info(string message);

        /// <summary>
        /// Shows child window with error message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Error(string message);
    }
}