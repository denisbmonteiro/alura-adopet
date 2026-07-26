using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Tests;

public class LeitorDeArquivoTest : IDisposable
{
    private readonly string caminhoArquivo;

    public LeitorDeArquivoTest()
    {
        //Setup
        var linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;0";
        var nomeArquivo = "lista.csv";

        File.WriteAllText(nomeArquivo, linha);
        caminhoArquivo = Path.GetFullPath(nomeArquivo);
    }

    [Fact]
    public void QuandoArquivoExistenteDeveRetornarUmaListaDePets()
    {
        //Arrange
        //Act
        var listaDePets = new LeitorDeArquivo(caminhoArquivo).RealizaLeitura()!;

        //Assert
        Assert.NotNull(listaDePets);
        Assert.Single(listaDePets);
        Assert.IsType<List<Pet>?>(listaDePets);
    }

    [Fact]
    public void QuandoArquivoNaoExistenteDeveRetornarNulo()
    {
        //Arrange
        //Act
        var listaDePets = new LeitorDeArquivo("").RealizaLeitura();

        //Assert
        Assert.Null(listaDePets);
    }

    [Fact]
    public void QuandoArquivoForNuloDeveRetornarNulo()
    {
        //Arrange
        //Act
        var listaDePets = new LeitorDeArquivo(null!).RealizaLeitura();

        //Assert
        Assert.Null(listaDePets);
    }

    public void Dispose()
    {
        //ClearDown
        File.Delete(caminhoArquivo);
    }
}