using Alura.Adopet.Console.Util;
using FluentResults;

namespace Alura.Adopet.Console.Comandos;

[DocComando(instrucao: "show", documentacao: "adopet show <ARQUIVO> comando que exibe no terminal o conteúdo do arquivo importado.")]
public class Show : IComando
{
    private readonly LeitorDeArquivo _leitorDeArquivo;

    public Show(LeitorDeArquivo leitorDeArquivo)
    {
        _leitorDeArquivo = leitorDeArquivo;
    }

    public Task<Result> ExecutarAsync()
    {
        try
        {
            return ExibeConteudoArquivo();
        }
        catch (Exception ex)
        {
            return Task.FromResult(Result.Fail(new Error("Exibição do arquivo falhou!").CausedBy(ex)));
        }
    }

    private Task<Result> ExibeConteudoArquivo()
    {
        var listaDePets = _leitorDeArquivo.RealizaLeitura();
        return Task.FromResult(Result.Ok().WithSuccess(new SuccessWithPets(listaDePets, "Exibição do arquivo realizada com sucesso!")));
    }
}