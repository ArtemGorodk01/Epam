using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using Xml.Export.Abstract;

namespace Xml.Export
{
    public class DefaultXmlExporter : IXmlExporter<Url>
    {
        private readonly Stream stream;

        public DefaultXmlExporter(Stream stream)
        {
            this.stream = stream ?? throw new ArgumentNullException(nameof(stream));
        }

        public void Export(IEnumerable<Url> data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            var head = new XElement(
                "urlAddresses",
                data.Select(d => d.ToXElement()).ToList());

            var document = new XDocument(head);
            document.Save(stream);
        }
    }
}
