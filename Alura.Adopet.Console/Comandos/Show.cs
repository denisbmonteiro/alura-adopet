using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Console.Comandos;

[DocComando(instrucao: "show", documentacao: "adopet show <ARQUIVO> comando que exibe no terminal o conteúdo do arquivo importado.")]
internal class Show : IComando
{
    public Task ExecutarAsync(string[] args)
    {
        ExibeConteudoArquivo(caminhoDoArquivoASerExibido: args[1]);
        return Task.CompletedTask;
    }

    private void ExibeConteudoArquivo(string caminhoDoArquivoASerExibido)
    {
        var leitor = new LeitorDeArquivo(caminhoDoArquivoASerExibido);
        var listaDePets = leitor.RealizaLeitura();

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