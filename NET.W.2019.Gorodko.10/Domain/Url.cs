using System.Collections.Generic;
using System.Text;

public class Url
{
    public string Scheme { get; set; }

    public string Host { get; set; }

    public List<string> Segments { get; set; }

    public Dictionary<string, string> Parameters { get; set; }

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
