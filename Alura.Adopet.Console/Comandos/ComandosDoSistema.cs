using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Console.Comandos;

public class ComandosDoSistema
{
    private readonly HttpClientPet _httpClientPet;
    private readonly LeitorDeArquivo _leitorDeArquivo;
    private readonly Dictionary<string, IComando> _comandosDoSistema;

    public ComandosDoSistema(string caminhoDoArquivo)
    {
        _httpClientPet = new HttpClientPet(new AdopetApiClientFactory().CreateClient("adopet"));
        _leitorDeArquivo = new LeitorDeArquivo(caminhoDoArquivo);
        _comandosDoSistema = new()
        {
            {"help", new Help() },
            {"import", new Import(_httpClientPet, _leitorDeArquivo) },
            {"list", new List(_httpClientPet) },
            {"show", new Show() }
        };
    }

    public IComando? this [string key] => _comandosDoSistema.ContainsKey(key) ? _comandosDoSistema[key] : null;
}