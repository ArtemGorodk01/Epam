using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Data.Parsing.Converting.Abstract;
using Data.Parsing.Validation.Abstract;
using Logging.Abstract;

namespace Data.Parsing.Converting
{
    /// <inheritdoc/>
    public class DefaultUrlConverter : IConverter<Url>
    {
        /// <summary>
        /// Regular expression.
        /// </summary>
        private const string Pattern = @"^(http|https|ftp)://(\w+\.\w+)(/)?(.[^\?]+)(\?(.*))?$";

        /// <summary>
        /// Logger.
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Validator.
        /// </summary>
        private readonly IValidator validator;

        /// <summary>
        /// Initials new instance of converter.
        /// </summary>
        /// <param name="validator">Validator.</param>
        /// <param name="logger">Logger.</param>
        public DefaultUrlConverter(IValidator validator, ILogger logger)
        {
            this.validator = validator ?? throw new ArgumentNullException(nameof(validator));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc/>
        public Url Convert(string line)
        {
            if (line == null)
            {
                throw new ArgumentNullException(nameof(line));
            }

            try
            {
                if (!validator.Validate(line))
                {
                    throw new ArgumentException();
                }

                var regex = new Regex(Pattern);
                var groups = regex.Match(line).Groups;

                if (groups.Count != 7)
                {
                    throw new ArgumentException();
                }

                var scheme = groups[1].ToString();
                var host = groups[2].ToString();
                var segments = groups[4].ToString();
                var parameters = groups[6].ToString();
                return new Url
                {
                    Scheme = scheme,
                    Host = host,
                    Segments = this.ParseSegments(segments),
                    Parameters = this.ParseParameters(parameters),
                };
            }
            catch (ArgumentException)
            {
                logger.Log($"Wrong url {line}");
                return null;
            }
        }

        private List<string> ParseSegments(string segments)
        {
            if (segments.Length == 0)
            {
                return new List<string>();
            }

            var segmentsArray = segments.Trim().Split('/');
            return segmentsArray.Where(s => s.Length != 0).ToList();
        }

        private Dictionary<string, string> ParseParameters(string parameters)
        {
            if (parameters.Length == 0)
            {
                return new Dictionary<string, string>();
            }

            var result = new Dictionary<string, string>();
            var paramArray = parameters.Trim().Split(' ');
            foreach (var pair in paramArray)
            {
                var keyValue = pair.Split('=');
                if (keyValue.Length != 2)
                {
                    throw new ArgumentException();
                }

                result.Add(keyValue[0], keyValue[1]);
            }

            return result;
        }
    }
}
