using System;
using System.Collections.Generic;
using Data.Parsing.Converting.Abstract;

namespace Data.Parsing.Abstract
{
    /// <summary>
    /// Provides string into collection of data.
    /// </summary>
    /// <typeparam name="T">Type of out data.</typeparam>
    public abstract class Parser<T>
    {
        /// <summary>
        /// Converter.
        /// </summary>
        protected readonly IConverter<T> converter;

        /// <summary>
        /// Initials new parser with converter.
        /// </summary>
        /// <param name="converter">Converter.</param>
        public Parser(IConverter<T> converter)
        {
            this.converter = converter ?? throw new ArgumentNullException(nameof(converter));
        }

        /// <summary>
        /// Parses the string into collection of data.
        /// </summary>
        /// <param name="text">Source string.</param>
        /// <returns>Collection with data.</returns>
        public abstract IEnumerable<T> Parse(string text);
    }
}
