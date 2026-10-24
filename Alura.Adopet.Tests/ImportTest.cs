using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Tests.Builder;
using Moq;

namespace Alura.Adopet.Tests;

public class ImportTest
{
    [Fact]
    public async Task QuandoListaVaziaNaoDeveChamarCreatePetAsync()
    {
        //Arrange
        var listaDePet = new List<Pet>();
        var leitorDeArquivo = LeitorDeArquivoMockBuilder.CriaMock(listaDePet);

        var httpClientPet = new Mock<HttpClientPet>(MockBehavior.Default, It.IsAny<HttpClient>());
        var import = new Import(httpClientPet.Object, leitorDeArquivo.Object);
        string[] args = { "import", "lista.csv" };

        //Act
        await import.ExecutarAsync(args);

        //Assert
        httpClientPet.Verify(_ => _.CreatePetAsync(It.IsAny<Pet>()), Times.Never);
    }
}