namespace SS.WebhookHelper.Models;
public class EmbedFooter
{
    public string Text { get; private set; }

    public string? Icon_url { get; private set; }

    public EmbedFooter(string text, string? icon_url)
    {
        Text = text;
        Icon_url = icon_url;
    }
}
