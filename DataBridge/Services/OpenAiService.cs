using Microsoft.Extensions.Diagnostics.HealthChecks;
using OpenAI.Chat;

namespace DataBridge.Services;

public class OpenAiService : IHealthCheck
{
    private readonly ChatClient _chatClient;

    public OpenAiService(ChatClient chatClient)
    {
        _chatClient = chatClient;
    }

    public async Task<string> GetMessageScoreAsync(string message)
    {
        message = message.Replace("\"", "\\\"");

        var prompt =
            $"You are an AI that evaluates customer service messages. Analyze the message and respond with a single integer from 0 to 100 based on the sentiment:\n\n" +
            "- 0: Extremely negative (dissatisfaction, anger, harsh language like 'terrible' or 'I want a refund').\n" +
            "- 100: Extremely positive (satisfaction, gratitude, 'fantastic' or 'thank you').\n" +
            "- 50: Neutral (informative, factual, or questions like 'I need help with my account').\n\n" +
            "Slightly Positive (50-70): Constructive or hopeful, despite issues.\n" +
            "Slightly Negative (30-50): Minor complaints without aggression.\n\n" +
            "Messages with strong frustration should score closer to 0. Resolved or positive messages should score higher.\n\n" +
            $"Message: \"{message}\"\n\n" +
            "Respond with a single integer between 0 and 100.";
        
        var result = await _chatClient.CompleteChatAsync(prompt);

        return result.Value.Content.First().Text;
    }

    // Its a hacky way of doing this and it doesn't actually do a full healthcheck of the API but it almost kinda does?
    // its better than nothing but
    // Todo: Implement a proper healthcheck for the OpenAI API
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(_chatClient != null
            ? HealthCheckResult.Healthy("OpenAI Chat API is available.")
            : HealthCheckResult.Unhealthy("OpenAI Chat API is unavailable."));
    }
}