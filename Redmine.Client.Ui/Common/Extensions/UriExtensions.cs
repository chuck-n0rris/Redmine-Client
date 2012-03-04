namespace System
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Provides methods to extract the data from uri.
    /// </summary>
    public static class UriExtensions
    {
        /// <summary>
        /// Extracts the name of the page form uri.
        /// </summary>
        /// <param name="uri">The instance if Uri.</param>
        /// <returns>
        /// The page name string.
        /// </returns>
        public static string ExtractPageName(this Uri uri)
        {
            const string Pattern = @"^(.*/(?<page>[^?.]*))";

            var regex = new Regex(Pattern, RegexOptions.ExplicitCapture);
            var match = regex.Match(uri.OriginalString);

            return match.Groups["page"].Value;
        }

        /// <summary>
        /// Extracts the uri parameters.
        /// </summary>
        /// <param name="uri">The instance if Uri.</param>
        /// <returns>
        /// Dictionary instance with matched parameters.
        /// </returns>
        public static Dictionary<string, string> ExtractParameters(this Uri uri)
        {
            const string Pattern = @"\?(?<params>.*)?";
            var resultDictionary = new Dictionary<string, string>();

            var regex = new Regex(Pattern, RegexOptions.ExplicitCapture);
            var match = regex.Match(uri.OriginalString);
            
            var paramsString = match.Groups["params"].Value;

            if (string.IsNullOrWhiteSpace(paramsString)) 
                return resultDictionary;

            // divides string with parameters to fragments like 'id=1'
            var fragments = paramsString.Split('&');

            foreach (var fragment in fragments)
            {
                // didides parameter string to key and value.
                var param = fragment.Split('=');

                if (param.Length != 2)
                    throw new Exception("Uri isn't in correct format.");

                resultDictionary.Add(param[0], param[1]);
            }

            return resultDictionary;
        }
    }
}