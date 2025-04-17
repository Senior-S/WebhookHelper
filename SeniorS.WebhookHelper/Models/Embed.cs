using System;
using System.Globalization;

namespace SeniorS.WebhookHelper.Models;
public class Embed
{
    public string? Title { get; private set; }

    public string Type { get; private set; } = "rich";

    public string? Description { get; private set; }

    public string? Url { get; private set; }

    public string? Timestamp { get; private set; }

    public int? Color { get; private set; }

    public EmbedFooter? Footer { get; private set; }

    public EmbedThumbnail? Thumbnail { get; private set; }

    public EmbedAuthor? Author { get; private set; }

    public string? Thread_Name { get; private set; }

    public Embed()
    {
    }

    public Embed SetTitle(string title)
    {
        this.Title = title;
        return this;
    }

    public Embed SetDescription(string description)
    {
        this.Description = description;
        return this;
    }

    public Embed SetUrl(string url)
    {
        this.Url = url;
        return this;
    }

    public Embed AddTimestamp()
    {
        this.Timestamp = DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ss.fffK", CultureInfo.InvariantCulture);
        return this;
    }

    public Embed SetColor(int color)
    {
        this.Color = color;
        return this;
    }

    public Embed SetHexColor(string hexColor)
    {
        if (hexColor.StartsWith("#")) hexColor = hexColor.Substring(1);

        this.Color = Convert.ToInt32(hexColor, 16);
        return this;
    }

    public Embed SetFooter(EmbedFooter footer)
    {
        this.Footer = footer;
        return this;
    }

    public Embed SetThumbnail(EmbedThumbnail thumbnail)
    {
        this.Thumbnail = thumbnail;
        return this;
    }

    public Embed SetAuthor(EmbedAuthor author)
    {
        this.Author = author;
        return this;
    }

    public Embed SetThreadName(string threadName)
    {
        this.Thread_Name = threadName;
        return this;
    }
}
