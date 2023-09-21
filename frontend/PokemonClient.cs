using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace frontend
{
   public class PokemonClient
   {
      private readonly JsonSerializerOptions options = new JsonSerializerOptions()
      {
         PropertyNameCaseInsensitive = true,
         PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
      };

      private readonly HttpClient client;
      private readonly ILogger<PokemonClient> _logger;

      public PokemonClient(HttpClient client, ILogger<PokemonClient> logger)
      {
         this.client = client;
         this._logger = logger;
      }

      public async Task<PokemonResult[]> GetGiftenorAsync()
{
    try
    {
        var responseMessage = await this.client.GetAsync("http://localhost:5900/pokemon");

        if (responseMessage != null && responseMessage.IsSuccessStatusCode)
        {
            var content = await responseMessage.Content.ReadAsStringAsync();
            var giftenorResponse = JsonSerializer.Deserialize<PokemonResponse>(content, options);

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
    return new PokemonResult[] { };
}

   }
}