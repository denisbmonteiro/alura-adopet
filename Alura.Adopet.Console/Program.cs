using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.UI;
using FluentResults;

var comandos = new ComandosDoSistema(args[1]);

string comando = args[0].Trim();
IComando? cmd = comandos[comando];

if (cmd is not null)
{
    var resultado = await cmd.ExecutarAsync(args);
    ConsoleUI.ExibeResultado(resultado);
}
else
{
    ConsoleUI.ExibeResultado(Result.Fail("Comando inválido!"));
}