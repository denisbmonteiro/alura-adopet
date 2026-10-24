using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Servicos;

namespace Alura.Adopet.Tests;

public class ImportTest
{
    [Fact]
    public async Task QuandoApiEstaNoArDeveRetornarListaDePet()
    {
        //Arrange
        var httpClientPet = new HttpClientPet(new AdopetApiClientFactory().CreateClient("adopet"));
        var import = new Import(httpClientPet);
        string[] args = { "import", "lista.csv" };

        //Act
        await import.ExecutarAsync(args);

        //Assert
        var listaPet = await httpClientPet.ListPetsAsync();

        Assert.NotNull(listaPet);
    }
}