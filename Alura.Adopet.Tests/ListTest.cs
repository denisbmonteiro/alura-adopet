using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Util;
using Alura.Adopet.Tests.Builder;

namespace Alura.Adopet.Tests;

public class ListTest
{
    [Fact]
    public async Task QuandoExecutarComandoListDeveRetornarListaDePets()
    {
        //Arrange
        var listaDePet = new List<Pet>();
        var pet = new Pet(new Guid("456b24f4-19e2-4423-845d-4a80e8854a41"), "Lima Limão", TipoPet.Gato);
        listaDePet.Add(pet);

        var httpClientPet = HttpClientPetMockBuilder.GetMockList(listaDePet);

        //Act
        var retorno = await new Console.Comandos.List(httpClientPet.Object).ExecutarAsync();

        //Assert
        var resultado = (SuccessWithPets) retorno.Successes[0];
        Assert.Single(resultado.Data);
    }
}