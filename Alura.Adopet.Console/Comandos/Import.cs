using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Console.Comandos;

[DocComando(instrucao: "import", documentacao: "adopet import <ARQUIVO> comando que realiza a importação do arquivo de pets.")]
public class Import : IComando
{
    private readonly HttpClientPet _httpClientPet;
    private readonly LeitorDeArquivo _leitorDeArquivo;

    public Import(HttpClientPet httpClientPet, LeitorDeArquivo leitorDeArquivo)
    {
        _httpClientPet = httpClientPet;
        _leitorDeArquivo = leitorDeArquivo;
    }

    public async Task ExecutarAsync(string[] args)
    {
        await ImportacaoArquivoPetAsync();
    }

    private async Task ImportacaoArquivoPetAsync()
    {
        var listaDePets = _leitorDeArquivo.RealizaLeitura();

        if (listaDePets is null)
        {
            System.Console.WriteLine("Nenhum pet encontrado no arquivo!");
            return;
        }

        foreach (var pet in listaDePets)
        {
            System.Console.WriteLine(pet);

            try
            {
                await _httpClientPet.CreatePetAsync(pet);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        System.Console.WriteLine("Importação concluída!");
    }
}