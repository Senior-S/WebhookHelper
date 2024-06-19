using System;

namespace SS.WebhookHelper.Models;
public class EmbedAuthor
{
    public string Name { get; private set; }

    public string Url { get; private set; }

    public string Icon_Url { get; private set; }

    public EmbedAuthor(string name, string url, string icon_Url)
    {
        if (url.Length > 0 && !url.StartsWith("https://")) throw new ArgumentException("Author url only supports https");
        Name = name;
        Url = url;
        Icon_Url = icon_Url;
    }
}
