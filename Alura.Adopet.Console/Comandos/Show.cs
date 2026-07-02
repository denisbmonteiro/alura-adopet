namespace Alura.Adopet.Console.Comandos;

[DocComando(instrucao: "show", documentacao: "adopet show <ARQUIVO> comando que exibe no terminal o conteúdo do arquivo importado.")]
internal class Show
{
    public void ExibeConteudoArquivo(string caminhoDoArquivoASerExibido)
    {
        LeitorDeArquivo leitor = new LeitorDeArquivo();
        var listaDePets = leitor.RealizaLeitura(caminhoDoArquivoASerLido: caminhoDoArquivoASerExibido);
        foreach (var pet in listaDePets)
        {
            System.Console.WriteLine(pet);
        }
    }
}