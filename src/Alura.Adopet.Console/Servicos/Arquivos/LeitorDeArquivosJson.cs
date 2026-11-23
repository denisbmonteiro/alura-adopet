using Alura.Adopet.Console.Servicos.Abstracoes;
using System.Text.Json;

namespace Alura.Adopet.Console.Servicos.Arquivos;

public class LeitorDeArquivosJson<Pet> : ILeitorDeArquivos<Pet>
{
    private string caminhoArquivo;

    public LeitorDeArquivosJson(string caminhoArquivo)
    {
        this.caminhoArquivo = caminhoArquivo;
    }

    public IEnumerable<Pet> RealizaLeitura()
    {
        using var stream = new FileStream(caminhoArquivo, FileMode.Open, FileAccess.Read);
        return JsonSerializer.Deserialize<IEnumerable<Pet>>(stream) ?? Enumerable.Empty<Pet>();
    }
}