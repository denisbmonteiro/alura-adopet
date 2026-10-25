using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Util;
using FluentResults;

namespace Alura.Adopet.Console.Comandos;

[DocComando(instrucao: "list", documentacao: "adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados da AdoPet.")]
public class List : IComando
{
    private readonly HttpClientPet _httpClientPet;

    public List(HttpClientPet httpClientPet)
    {
        _httpClientPet = httpClientPet;
    }

    public Task<Result> ExecutarAsync()
    {
        return ListaDadosPetsDaAPIAsync();
    }

    private async Task<Result> ListaDadosPetsDaAPIAsync()
    {
        try
        {
            var pets = await _httpClientPet.ListPetsAsync() ?? Enumerable.Empty<Pet>();
            return Result.Ok().WithSuccess(new SuccessWithPets(pets, "Listagem de Pets realizada com sucesso!"));
        }
        catch (Exception ex)
        {
            return Result.Fail(new Error("Listagem falhou!").CausedBy(ex));
        }
    }
}