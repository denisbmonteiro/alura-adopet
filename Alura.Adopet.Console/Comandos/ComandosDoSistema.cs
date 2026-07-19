using Alura.Adopet.Console.Servicos;

namespace Alura.Adopet.Console.Comandos;

public class ComandosDoSistema
{
    private HttpClientPet _httpClientPet;
    private Dictionary<string, IComando> _comandosDoSistema;

    public ComandosDoSistema()
    {
        _httpClientPet = new HttpClientPet(new AdopetApiClientFactory().CreateClient("adopet"));
        _comandosDoSistema = new()
        {
            {"help", new Help() },
            {"import", new Import(_httpClientPet) },
            {"list", new List(_httpClientPet) },
            {"show", new Show() }
        };
    }

    public IComando? this [string key] => _comandosDoSistema.ContainsKey(key) ? _comandosDoSistema[key] : null;
}