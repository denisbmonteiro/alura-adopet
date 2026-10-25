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
        var leitorDeArquivo = LeitorDeArquivoMockBuilder.GetMock(listaDePet);

        var httpClientPet = new Mock<HttpClientPet>(MockBehavior.Default, It.IsAny<HttpClient>());
        var import = new Import(httpClientPet.Object, leitorDeArquivo.Object);
        string[] args = { "import", "lista.csv" };

        //Act
        await import.ExecutarAsync(args);

        //Assert
        httpClientPet.Verify(_ => _.CreatePetAsync(It.IsAny<Pet>()), Times.Never);
    }

    [Fact]
    public async Task QuandoArquivoNaoExistenteDeveGerarException()
    {
        //Arrange
        var listaDePet = new List<Pet>();
        var leitorDeArquivo = LeitorDeArquivoMockBuilder.GetMock(listaDePet);
        leitorDeArquivo.Setup(_ => _.RealizaLeitura()).Throws<FileNotFoundException>();

        var httpClientPet = HttpClientPetMockBuilder.GetMock();
        var import = new Import(httpClientPet.Object, leitorDeArquivo.Object);
        string[] args = { "import", "lista.csv" };

        //Act+Assert
        await Assert.ThrowsAnyAsync<Exception>(() => import.ExecutarAsync(args));
    }

    [Fact]
    public async Task QuandoPetEstiverNoArquivoDeveSerImportado()
    {
        //Arrange
        var listaDePet = new List<Pet>();
        var pet = new Pet(new Guid("456b24f4-19e2-4423-845d-4a80e8854a41"), "Lima Limão", TipoPet.Gato);
        listaDePet.Add(pet);

        var leitorDeArquivo = LeitorDeArquivoMockBuilder.GetMock(listaDePet);
        var httpClientPet = HttpClientPetMockBuilder.GetMock();

        var import = new Import(httpClientPet.Object, leitorDeArquivo.Object);
        string[] args = { "import", "lista.csv" };

        //Act
        var resultado = await import.ExecutarAsync(args);

        //Assert
        Assert.True(resultado.IsSuccess);
    }
}