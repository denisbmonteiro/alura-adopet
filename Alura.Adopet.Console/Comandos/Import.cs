using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Util;
using FluentResults;

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

    public async Task<Result> ExecutarAsync(string[] args)
    {
        return await ImportacaoArquivoPetAsync();
    }

    private async Task<Result> ImportacaoArquivoPetAsync()
    {
        try
        {
            var listaDePets = _leitorDeArquivo.RealizaLeitura();

            foreach (var pet in listaDePets)
                await _httpClientPet.CreatePetAsync(pet);

            return Result.Ok().WithSuccess(new SuccessWithPets(listaDePets, "Importação realizada com sucesso!"));
        }
        catch (Exception ex)
        {
            return Result.Fail(new Error("Importação falhou!").CausedBy(ex));
        }
    }
}