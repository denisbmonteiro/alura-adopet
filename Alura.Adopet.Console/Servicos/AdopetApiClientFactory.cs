using System.Net.Http.Headers;

namespace Alura.Adopet.Console.Servicos;

internal class AdopetApiClientFactory : IHttpClientFactory
{
    private string url = "http://localhost:5057";

    public HttpClient CreateClient(string name)
    {
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Accept.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        httpClient.BaseAddress = new Uri(url);
        return httpClient;
    }
}