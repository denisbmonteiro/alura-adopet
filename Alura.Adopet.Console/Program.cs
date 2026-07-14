using Alura.Adopet.Console.Comandos;

var comandos = new ComandosDoSistema();

Console.ForegroundColor = ConsoleColor.Green;

try
{
    string comando = args[0].Trim();
    IComando? cmd = comandos[comando];

    if (cmd is not null)
        await cmd.ExecutarAsync(args);
    else
        Console.WriteLine("Comando inválido!");
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Aconteceu uma exceção: {ex.Message}");
}
finally
{
    Console.ForegroundColor = ConsoleColor.White;
}