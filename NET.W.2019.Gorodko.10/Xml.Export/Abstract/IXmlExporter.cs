using System.Collections.Generic;

namespace Xml.Export.Abstract
{
    /// <summary>
    /// Provides exporting to xml.
    /// </summary>
    /// <typeparam name="T">Type of data to export.</typeparam>
    public interface IXmlExporter<T>
    {
        /// <summary>
        /// Exports collection of data into xml.
        /// </summary>
        /// <param name="data">Collection of data.</param>
        void Export(IEnumerable<T> data);
    }
}
