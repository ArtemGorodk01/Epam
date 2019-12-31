using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

public static class UrlMapper
{
    public static XElement ToXElement(this Url url)
    {
        if (url == null)
        {
            throw new ArgumentNullException(nameof(url));
        }

        return new XElement(
                   "urlAddress",
                   new XElement("host", new XAttribute("name", url.Host)),
                   XUriFromSegments(url.Segments),
                   XParametersFromParameters(url.Parameters));
    }

    private static XElement XUriFromSegments(IEnumerable<string> segments)
    {
        var segmentsX = segments.Select(segment => new XElement("segment", segment))
                                .ToList();
        return new XElement("uri", segmentsX);
    }

    private static XElement XParametersFromParameters(IDictionary<string, string> parameters)
    {
        var parametersX = parameters.Select(p => new XElement("parameter",
                                     new XAttribute("value", p.Value),
                                     new XAttribute("key", p.Key)))
                                    .ToList();
        return new XElement("parameters", parametersX);
    }
}
