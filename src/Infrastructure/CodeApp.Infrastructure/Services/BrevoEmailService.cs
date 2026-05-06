using System.Text;
using System.Text.Json;
using CodeApp.Application.Abstractions.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CodeApp.Infrastructure.Services;

public class BrevoEmailService : IEmailService
{
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;
    private readonly ILogger<BrevoEmailService> _logger;

    public BrevoEmailService(IConfiguration configuration, HttpClient httpClient, ILogger<BrevoEmailService> logger)
    {
        _configuration = configuration;
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task SendEmailAsync(string to, string subject, string body)
    {
        try
        {
            var apiKey = _configuration["Brevo:ApiKey"];
            var senderEmail = _configuration["Brevo:SenderEmail"];
            var senderName = _configuration["Brevo:SenderName"] ?? "CodeApp";

            if (string.IsNullOrWhiteSpace(apiKey) || string.IsNullOrWhiteSpace(senderEmail))
            {
                _logger.LogWarning("Brevo email skipped because Brevo:ApiKey or Brevo:SenderEmail is missing.");
                return;
            }

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

            var response = await _httpClient.PostAsync("https://api.brevo.com/v3/smtp/email", content);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError(
                    "Brevo email failed. StatusCode: {StatusCode}, To: {To}, Response: {ResponseBody}",
                    response.StatusCode,
                    to,
                    responseBody);
                return;
            }

            _logger.LogInformation("Brevo email sent successfully. To: {To}", to);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Brevo email send threw exception. To: {To}", to);
        }
    }
}
