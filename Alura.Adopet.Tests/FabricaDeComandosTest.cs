using Alura.Adopet.Console.Comandos;

namespace Alura.Adopet.Tests;

public class FabricaDeComandosTest
{
    [Fact]
    public async Task DadoUmParametroDeveRetornarUmTipoImport()
    {
        //Arrange
        string[] args = { "import", "lista.csv" };

        //Act
        var comando = FabricaDeComandos.CriarComando(args);

        //Assert
        Assert.IsType<Import>(comando);
    }

    [Fact]
    public async Task DadoUmParametroInvalidoDeveRetornarNulo()
    {
        //Arrange
        string[] args = { "invalid", "lista.csv" };

        //Act
        var comando = FabricaDeComandos.CriarComando(args);

        //Assert
        Assert.Null(comando);
    }

    [Fact]
    public async Task DadoUmArrayDeArgumentosNuloDeveRetornarNulo()
    {
        //Arrange
        //Act
        var comando = FabricaDeComandos.CriarComando(null);

        //Assert
        Assert.Null(comando);
    }

    [Fact]
    public async Task DadoUmArrayDeArgumentosVazioDeveRetornarNulo()
    {
        //Arrange
        string[] args = { };

        //Act
        var comando = FabricaDeComandos.CriarComando(args);

        //Assert
        Assert.Null(comando);
    }
}