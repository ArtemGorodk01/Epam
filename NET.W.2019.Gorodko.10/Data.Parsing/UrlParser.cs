﻿using System;
using System.Linq;
using System.Collections.Generic;
using Data.Parsing.Abstract;
using Data.Parsing.Converting.Abstract;
using Data.Parsing.Validation.Abstract;

namespace Data.Parsing
{
    /// <inheritdoc/>
    public class UrlParser : Parser<Url>
    {
        /// <inheritdoc/>
        public UrlParser(IConverter<Url> converter) : base(converter)
        {
        }

        /// <inheritdoc/>
        public override IEnumerable<Url> Parse(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            var lines = text.Trim().Split('\n');
            return lines.Select(line => converter.Convert(line))
                        .Where(line => line != null)
                        .ToList();
        }
    }
}
