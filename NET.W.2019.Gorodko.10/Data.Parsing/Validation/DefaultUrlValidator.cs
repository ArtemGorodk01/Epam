using System;
using System.Text.RegularExpressions;
using Data.Parsing.Validation.Abstract;

namespace Data.Parsing.Validation
{
    /// <inheritdoc/>
    public class DefaultUrlValidator : IValidator
    {
        /// <summary>
        /// Regular expression.
        /// </summary>
        private const string Pattern = @"^(http|https|ftp)://(\w+\.\w+)(/)?(.[^\?]+)(\?(.*))?$";

        /// <inheritdoc/>
        public bool Validate(string line)
        {
            if (line == null)
            {
                throw new ArgumentNullException(nameof(line));
            }

            return Regex.IsMatch(line, Pattern);
        }
    }
}
