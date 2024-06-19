using System.Collections.Generic;
using System;

namespace SS.WebhookHelper.Models;
public class WebhookMessage
{
    public string? Content { get; private set; }

    public string? Username { get; private set; }

    public string? Avatar_Url { get; private set; }

    public List<Embed> Embeds { get; private set; } = [];

    public WebhookMessage(string? username = null, string? content = null, string? avatarUrl = null)
    {
        Content = content;
        Username = username;
        Avatar_Url = avatarUrl;
    }

    public void AppendEmbed(Embed embed)
    {
        if (this.Embeds.Count >= 10) throw new ArgumentOutOfRangeException("Only 10 embeds are allowed per message");
        this.Embeds.Add(embed);
    }
}