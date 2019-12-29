using System;
using System.Collections.Generic;
using Data.Parsing.Converting.Abstract;
using Data.Parsing.Validation.Abstract;

namespace Data.Parsing.Abstract
{
    public abstract class Parser<T>
    {
        protected readonly IConverter<T> converter;

        protected readonly IValidator validator;

        public Parser(IConverter<T> converter, IValidator validator)
        {
            this.converter = converter ?? throw new ArgumentNullException(nameof(converter));
            this.validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        public abstract IEnumerable<T> Parse(string text);
    }
}
