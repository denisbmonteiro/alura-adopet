namespace Alura.Adopet.Console;

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