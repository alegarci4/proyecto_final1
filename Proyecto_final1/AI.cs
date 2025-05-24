using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Proyecto_final1
{
    public class AI
    {
        private readonly HttpClient _httpClient;
        private const string GroqApiUrl = "https://api.groq.com/openai/v1/chat/completions";
        private const string ApiKey = "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"; // API key

        public AI()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {ApiKey}");
        }

        public async Task<string> ObtenerBusqueda(string prompt)
        {
            try
            {
                var requestBody = new
                {
                    messages = new[]
                    {
                new
                {
                    role = "user",
                    content = prompt
                }
            },
                    model = "llama3-70b-8192", // Modelo API
                    temperature = 0.7,
                    max_tokens = 1024,
                    stream = false
                };

                var json = JsonSerializer.Serialize(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(GroqApiUrl, content);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error {response.StatusCode}: {errorContent}");
                }

                var responseJson = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(responseJson);

                return doc.RootElement
                    .GetProperty("choices")[0]
                    .GetProperty("message")
                    .GetProperty("content")
                    .GetString();
            }
            catch (Exception ex)
            {
                return $"Error al obtener respuesta de Groq: {ex.Message}";
            }
        }
    }
}