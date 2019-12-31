using System;
using System.Collections.Generic;
using Data.Parsing.Converting.Abstract;

namespace Data.Parsing.Abstract
{
    public abstract class Parser<T>
    {
        protected readonly IConverter<T> converter;

        public Parser(IConverter<T> converter)
        {
            this.converter = converter ?? throw new ArgumentNullException(nameof(converter));
        }

        public abstract IEnumerable<T> Parse(string text);
    }
}
