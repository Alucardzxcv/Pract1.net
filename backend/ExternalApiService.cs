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
        var response = await _httpClient.GetStringAsync("https://g.tenor.com/v1/search?q=exciteds&key=LIVDSRZULELA&limit=8");
        return response;
    }
}
