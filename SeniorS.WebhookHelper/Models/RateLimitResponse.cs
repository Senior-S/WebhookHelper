namespace SeniorS.WebhookHelper.Models;
public class RateLimitResponse
{
    public string Message { get; set; }

    public float Retry_After { get; set; }

    public bool Global { get; set; }

    public int? Code { get; set; }
}
