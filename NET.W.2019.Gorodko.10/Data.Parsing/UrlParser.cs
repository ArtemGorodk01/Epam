using System;
using System.Linq;
using System.Collections.Generic;
using Data.Parsing.Abstract;
using Data.Parsing.Converting.Abstract;
using Data.Parsing.Validation.Abstract;

namespace Data.Parsing
{
    public class UrlParser : Parser<Url>
    {
        public UrlParser(IConverter<Url> converter, IValidator validator) : base(converter, validator)
        {
        }

        public override IEnumerable<Url> Parse(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            var lines = text.Trim().Split('\n');
            return lines.Where(line => validator.Validate(line))
                        .Select(line => converter.Convert(line))
                        .ToList();
        }
    }
}
