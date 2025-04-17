using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SeniorS.WebhookHelper.Models;
using SS.WebhookHelper.Models;

namespace SeniorS.WebhookHelper;

public class WebhookHelper
{
    public static async Task<int> PostWebhookAsync(string webhookUrl, WebhookMessage message)
    {
        using HttpClient httpClient = new();
        DefaultContractResolver contractResolver = new DefaultContractResolver
        {
            NamingStrategy = new SnakeCaseNamingStrategy()
        };

        string jsonMessage = JsonConvert.SerializeObject(message,
            new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, ContractResolver = contractResolver });
        StringContent content = new(jsonMessage, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await httpClient.PostAsync(new Uri(webhookUrl), content);

        if (!response.IsSuccessStatusCode)
        {
            string responseContent = await response.Content.ReadAsStringAsync();

            RateLimitResponse? rateLimitResponse = JsonConvert.DeserializeObject<RateLimitResponse>(responseContent,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, ContractResolver = contractResolver });
            if (rateLimitResponse != null)
            {
                return (int)rateLimitResponse.Retry_After;
            }
        }

        return 0;
    }
    
    public static async Task<int> PostWebhookWithFilesAsync(string webhookUrl, WebhookMessage message)
    {
        if (message.Files == null)
        {
            throw new ArgumentNullException(nameof(message.Files));
        }
        
        using HttpClient httpClient = new();
        DefaultContractResolver contractResolver = new()
        {
            NamingStrategy = new SnakeCaseNamingStrategy()
        };

        string jsonMessage = JsonConvert.SerializeObject(message,
            new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, ContractResolver = contractResolver });

        MultipartFormDataContent form = new();
        form.Add(new StringContent(jsonMessage, Encoding.UTF8, "application/json"), "payload_json");

        for (int i = 0; i < message.Files.Count; i++)
        {
            File file = message.Files[i];
            ByteArrayContent fileContent = new(file.Content, 0, file.Content.Length);
            fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            form.Add(fileContent, $"files[{i}]", file.Name);
        }
        
        HttpResponseMessage response = await httpClient.PostAsync(new Uri(webhookUrl), form);

        if (!response.IsSuccessStatusCode)
        {
            string responseContent = await response.Content.ReadAsStringAsync();

            RateLimitResponse? rateLimitResponse = JsonConvert.DeserializeObject<RateLimitResponse>(responseContent,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, ContractResolver = contractResolver });
            if (rateLimitResponse != null)
            {
                return (int)rateLimitResponse.Retry_After;
            }
        }

        return 0;
    }
}