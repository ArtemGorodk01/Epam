using System.Collections.Generic;

namespace Xml.Export.Abstract
{
    public interface IXmlExporter<T>
    {
        void Export(IEnumerable<T> data);
    }
}
