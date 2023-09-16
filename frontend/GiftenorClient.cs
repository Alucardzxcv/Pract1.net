using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace frontend
{
   public class GiftenorClient
   {
      private readonly JsonSerializerOptions options = new JsonSerializerOptions()
      {
         PropertyNameCaseInsensitive = true,
         PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
      };

      private readonly HttpClient client;
      private readonly ILogger<GiftenorClient> _logger;

      public GiftenorClient(HttpClient client, ILogger<GiftenorClient> logger)
      {
         this.client = client;
         this._logger = logger;
      }

      public async Task<GiftenorResult[]> GetGiftenorAsync()
{
    try
    {
        var responseMessage = await this.client.GetAsync("http://ip172-18-0-15-ck2up9mfml8g00aplcng-80.direct.labs.play-with-docker.com/api/externaldata");

        if (responseMessage != null && responseMessage.IsSuccessStatusCode)
        {
            var content = await responseMessage.Content.ReadAsStringAsync();
            var giftenorResponse = JsonSerializer.Deserialize<GiftenorResponse>(content, options);

            if (giftenorResponse != null)
            {
                return giftenorResponse.Results;
            }
        }
    }
    catch (HttpRequestException ex)
    {
        _logger.LogError($"Error deserializing JSON: {ex.Message}");
        throw;
    }
    return new GiftenorResult[] { };
}

   }
}