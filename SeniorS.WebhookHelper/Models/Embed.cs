using System;
using System.Globalization;

namespace SS.WebhookHelper.Models;
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

    public void SetTitle(string title)
    {
        this.Title = title;
    }

    public void SetDescription(string description)
    {
        this.Description = description;
    }

    public void SetUrl(string url)
    {
        this.Url = url;
    }

    public void AddTimestamp()
    {
        this.Timestamp = DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ss.fffK", CultureInfo.InvariantCulture);
    }

    public void SetColor(int color)
    {
        this.Color = color;
    }

    public void SetHexColor(string hexColor)
    {
        if (hexColor.StartsWith("#")) hexColor = hexColor.Substring(1);

        this.Color = Convert.ToInt32(hexColor, 16);
    }

    public void SetFooter(EmbedFooter footer)
    {
        this.Footer = footer;
    }

    public void SetThumbnail(EmbedThumbnail thumbnail)
    {
        this.Thumbnail = thumbnail;
    }

    public void SetAuthor(EmbedAuthor author)
    {
        this.Author = author;
    }

    public void SetThreadName(string threadName)
    {
        this.Thread_Name = threadName;
    }
}
