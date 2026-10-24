using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Tests.Builder;

namespace Alura.Adopet.Tests;

public class ImportIntegrationTest
{
    [Fact]
    public async Task QuandoApiEstaNoArDeveRetornarListaDePet()
    {
        //Arrange
        var listaDePet = new List<Pet>();
        var pet = new Pet(new Guid("456b24f4-19e2-4423-845d-4a80e8854a41"), "Lima Limão", TipoPet.Gato);
        listaDePet.Add(pet);

        var leitorDeArquivo = LeitorDeArquivoMockBuilder.GetMock(listaDePet);

        var httpClientPet = new HttpClientPet(new AdopetApiClientFactory().CreateClient("adopet"));
        var import = new Import(httpClientPet, leitorDeArquivo.Object);
        string[] args = { "import", "lista.csv" };

        //Act
        await import.ExecutarAsync(args);

        //Assert
        var listaPet = await httpClientPet.ListPetsAsync();

        Assert.NotNull(listaPet);
    }
}