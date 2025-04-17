using System;

namespace SeniorS.WebhookHelper.Models;
public class EmbedThumbnail
{
    public string Url { get; private set; }

    public int? Height { get; private set; }

    public int? Width { get; private set; }

    public EmbedThumbnail(string url, int? height = null, int? width = null)
    {
        if (!url.StartsWith("https://")) throw new ArgumentException("Thumbnail url only supports https");

        Url = url;
        Height = height;
        Width = width;
    }
}
