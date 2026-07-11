using System.Net.Http.Headers;
using System.Net.Http.Json;
using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Servicos;

public class HttpClientPet
{
    private readonly HttpClient _client;

    public HttpClientPet(string uri = "http://localhost:5057")
    {
        _client = SetupHttpClient(uri);
    }

    private static HttpClient SetupHttpClient(string url)
    {
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Accept.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        httpClient.BaseAddress = new Uri(url);
        return httpClient;
    }

    public Task CreatePetAsync(Pet pet)
    {
        return _client.PostAsJsonAsync("pet/add", pet);
    }

    public async Task<IEnumerable<Pet>?> ListPetsAsync()
    {
        var response = await _client.GetAsync("pet/list");
        return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
    }
}