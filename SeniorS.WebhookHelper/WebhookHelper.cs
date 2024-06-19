using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SS.WebhookHelper.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SS.WebhookHelper;

public class WebhookHelper
{
    public static async Task<int> PostWebhookAsync(string webhookUrl, WebhookMessage message)
    {
        using HttpClient httpClient = new();
        DefaultContractResolver contractResolver = new DefaultContractResolver
        {
            NamingStrategy = new SnakeCaseNamingStrategy()
        };

        string jsonMessage = JsonConvert.SerializeObject(message, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, ContractResolver = contractResolver });
        StringContent content = new StringContent(jsonMessage, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await httpClient.PostAsync(new Uri(webhookUrl), content);

        if (!response.IsSuccessStatusCode)
        {
            string responseContent = await response.Content.ReadAsStringAsync();

            RateLimitResponse? rateLimitResponse = JsonConvert.DeserializeObject<RateLimitResponse>(responseContent, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, ContractResolver = contractResolver });
            if (rateLimitResponse != null)
            {
                return (int)rateLimitResponse.Retry_After;
            }
        }

        httpClient.Dispose();
        return 0;
    }
}
