using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Tests;

public class PetAPartirDoCsvTest
{
    [Fact]
    public void QuandoStringForValidaDeveRetornarUmPet()
    {
        //Arrange
        var linha = "bcdcb7a4-1279-4a6b-97e9-da6378ae6437;Jujuba;2";

        //Act
        var pet = linha.ConverteDoTexto();

        //Assert
        Assert.NotNull(pet);
    }
}