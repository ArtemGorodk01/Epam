using System.Collections.Generic;
using System.Text;

/// <summary>
/// Provides working with url.
/// </summary>
public class Url
{
    /// <summary>
    /// Gets or sets scheme.
    /// </summary>
    public string Scheme { get; set; }

    /// <summary>
    /// Gets or sets name of host.
    /// </summary>
    public string Host { get; set; }

    /// <summary>
    /// Gets or sets segments.
    /// </summary>
    public List<string> Segments { get; set; }

    /// <summary>
    /// Gets or sets parameters.
    /// </summary>
    public Dictionary<string, string> Parameters { get; set; }

    /// <inheritdoc/>
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(Scheme).AppendLine(Host);
        foreach (var segment in Segments)
        {
            sb.AppendLine(segment);
        }

        foreach (var pair in Parameters)
        {
            sb.AppendLine(pair.Key + "=" + pair.Value);
        }

        return sb.ToString();
    }
}
