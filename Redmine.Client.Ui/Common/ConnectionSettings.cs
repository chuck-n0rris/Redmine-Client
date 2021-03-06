﻿namespace Redmine.Client.Ui.Common
{
    using System.Collections.Generic;

    /// <summary>
    /// Contains fields for login to the redmine client.
    /// </summary>
    public class ConnectionSettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether authentication required.
        /// </summary>
        public bool AuthenticationRequired { get; set; }

        /// <summary>
        /// Gets or sets the login.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        public string Url { get; set; }
    }
}