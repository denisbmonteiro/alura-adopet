using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Tests;

public class PetAPartirDoCsvTest
{
    [Fact]
    public void QuandoStringForValidaDeveRetornarUmPet()
    {
        //Arrange
        var linha = "bcdcb7a4-1279-4a6b-97e9-da6378ae6437;Jujuba;1";

        //Act
        var pet = linha.ConverteDoTexto();

        //Assert
        Assert.NotNull(pet);
    }

    [Fact]
    public void QuandoStringNulaDeveLancarArgumentNullException()
    {
        //Arrange
        string? linha = null;

        //Act + Assert
        Assert.Throws<ArgumentNullException>(() => linha.ConverteDoTexto());
    }

    [Fact]
    public void QuandoStringVaziaDeveLancarArgumentException()
    {
        //Arrange
        string? linha = string.Empty;

        //Act + Assert
        Assert.Throws<ArgumentException>(() => linha.ConverteDoTexto());
    }

    [Fact]
    public void QuandoCamposInsuficientesDeveLancarArgumentException()
    {
        //Arrange
        string? linha = "bcdcb7a4-1279-4a6b-97e9-da6378ae6437;Jujuba";

        //Act + Assert
        Assert.Throws<ArgumentException>(() => linha.ConverteDoTexto());
    }

    [Fact]
    public void QuandoGuidInvalidoDeveLancarArgumentException()
    {
        //Arrange
        string? linha = "bcdcb7a4;Jujuba;1";

        //Act + Assert
        Assert.Throws<ArgumentException>(() => linha.ConverteDoTexto());
    }

    [Fact]
    public void QuandoTipoInvalidoDeveLancarArgumentException()
    {
        //Arrange
        string? linha = "bcdcb7a4-1279-4a6b-97e9-da6378ae6437;Jujuba;2";

        //Act + Assert
        Assert.Throws<ArgumentException>(() => linha.ConverteDoTexto());
    }
}