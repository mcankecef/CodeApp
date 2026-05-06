using System.Text;
using System.Text.Json;
using CodeApp.Application.Abstractions.Services;
using Microsoft.Extensions.Configuration;

namespace CodeApp.Infrastructure.Services;

public class BrevoEmailService : IEmailService
{
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;

    public BrevoEmailService(IConfiguration configuration, HttpClient httpClient)
    {
        _configuration = configuration;
        _httpClient = httpClient;
    }

    public async Task SendEmailAsync(string to, string subject, string body)
    {
        try
        {
            var apiKey = _configuration["Brevo:ApiKey"];
            var senderEmail = _configuration["Brevo:SenderEmail"];
            var senderName = _configuration["Brevo:SenderName"] ?? "CodeApp";

            if (string.IsNullOrWhiteSpace(apiKey) || string.IsNullOrWhiteSpace(senderEmail))
                return;

            var payload = new
            {
                sender = new { name = senderName, email = senderEmail },
                to = new[] { new { email = to } },
                subject,
                htmlContent = body
            };

            var json = JsonSerializer.Serialize(payload);
            using var content = new StringContent(json, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("api-key", apiKey);

            await _httpClient.PostAsync("https://api.brevo.com/v3/smtp/email", content);
        }
        catch
        {
            // Intentionally swallow to keep forgot-password response generic.
        }
    }
}
