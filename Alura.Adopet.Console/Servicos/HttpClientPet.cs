using System.Net.Http.Json;
using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Servicos;

public class HttpClientPet
{
    private readonly HttpClient _client;

    public HttpClientPet(HttpClient client)
    {
        _client = client;
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