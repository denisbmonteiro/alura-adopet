using Alura.Adopet.Console.Servicos;

namespace Alura.Adopet.Console.Comandos;

[DocComando(instrucao: "list", documentacao: "adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados da AdoPet.")]
internal class List : IComando
{
    private readonly HttpClientPet _httpClientPet;

    public List(HttpClientPet httpClientPet)
    {
        _httpClientPet = httpClientPet;
    }

    public Task ExecutarAsync(string[] args)
    {
        return ListaDadosPetsDaAPIAsync();
    }

    private async Task ListaDadosPetsDaAPIAsync()
    {
        System.Console.WriteLine("----- Lista de Pets importados no sistema -----");

        var pets = await _httpClientPet.ListPetsAsync();

        if (pets is null)
        {
            System.Console.WriteLine("Nenhum pet encontrado!");
            return;
        }

        foreach (var pet in pets)
        {
            System.Console.WriteLine(pet);
        }
    }
}