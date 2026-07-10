using System.Reflection;
using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Tests;

public class GeraDocumentacaoTest
{
    [Fact]
    public void QuandoExistemComandosDeveRetornarDicionarioNaoVazio()
    {
        //Arrange
        var assemblyComOTipoDocComando = Assembly.GetAssembly(typeof(DocComando))!;

        //Act
        var dicionario = DocumentacaoDoSistema.ToDictionary(assemblyComOTipoDocComando);

        //Assert
        Assert.NotNull(dicionario);
        Assert.NotEmpty(dicionario);
        Assert.Equal(4, dicionario.Count);
    }
}