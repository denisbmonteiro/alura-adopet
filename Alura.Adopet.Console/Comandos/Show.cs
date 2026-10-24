using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Console.Comandos;

[DocComando(instrucao: "show", documentacao: "adopet show <ARQUIVO> comando que exibe no terminal o conteúdo do arquivo importado.")]
internal class Show : IComando
{
    private readonly LeitorDeArquivo _leitorDeArquivo;

    public Show(LeitorDeArquivo leitorDeArquivo)
    {
        _leitorDeArquivo = leitorDeArquivo;
    }

    public Task ExecutarAsync(string[] args)
    {
        ExibeConteudoArquivo(args[1]);
        return Task.CompletedTask;
    }

    private void ExibeConteudoArquivo(string caminhoDoArquivoASerExibido)
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
        }
    }
}