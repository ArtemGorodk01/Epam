using System;
using System.Text.RegularExpressions;
using Data.Parsing.Validation.Abstract;

namespace Data.Parsing.Validation
{
    public class DefaultUrlValidator : IValidator
    {
        private const string Pattern = @"^(http|https|ftp)://(\w+\.\w+)(/)?(.[^\?]+)(\?(.*))?$";

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
