using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Util;
using Alura.Adopet.Tests.Builder;

namespace Alura.Adopet.Tests;

public class ShowTest
{
    [Fact]
    public async Task QuandoArquivoExistenteDeveRetornarMensagemDeSucesso()
    {
        //Arrange
        var listaDePet = new List<Pet>();
        var pet = new Pet(new Guid("456b24f4-19e2-4423-845d-4a80e8854a41"), "Lima Limão", TipoPet.Gato);
        listaDePet.Add(pet);

        var leitor = LeitorDeArquivoMockBuilder.GetMock(listaDePet);
        leitor.Setup(_ => _.RealizaLeitura());

        var show = new Show(leitor.Object);

        //Act
        var resultado = await show.ExecutarAsync();

        //Assert
        var sucesso = (SuccessWithPets) resultado.Successes[0];

        Assert.NotNull(resultado);
        Assert.Equal("Exibição do arquivo realizada com sucesso!", sucesso.Message);
    }
}