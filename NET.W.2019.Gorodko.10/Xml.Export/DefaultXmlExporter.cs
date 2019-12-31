using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using Xml.Export.Abstract;

namespace Xml.Export
{
    /// <inheritdoc/>
    public class DefaultXmlExporter : IXmlExporter<Url>
    {
        private readonly Stream stream;

        /// <summary>
        /// Initials new instance of xml exporter.
        /// </summary>
        /// <param name="stream">Stream.</param>
        public DefaultXmlExporter(Stream stream)
        {
            this.stream = stream ?? throw new ArgumentNullException(nameof(stream));
        }

        /// <inheritdoc/>
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
