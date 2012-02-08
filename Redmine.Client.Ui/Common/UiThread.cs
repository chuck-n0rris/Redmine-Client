namespace Redmine.Client.Ui.Common
{
    using System;
    using System.Windows;

    /// <summary>
    /// Provides operation for ensuring a task is dispatched on the UI thread
    /// </summary>
    public static class UiThread
    {
        /// <summary>
        /// Dispatches the specified task on the ui thread
        /// </summary>
        /// <param name="task">The task to be dispatched</param>
        public static void Dispatch(Action task)
        {
            if (Deployment.Current.CheckAccess())
            {
                task();
                return;
            }

            Deployment.Current.Dispatcher.BeginInvoke(task);
        }
    }
}