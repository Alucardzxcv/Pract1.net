using System;
using System.Net.Http;
using System.Threading.Tasks;

public class ExternalApiService
{
    private readonly HttpClient _httpClient;

    public ExternalApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetExternalApiData()
    {
        var response = await _httpClient.GetStringAsync("https://pokeapi.co/api/v2/pokemon");
        return response;
    }
}
