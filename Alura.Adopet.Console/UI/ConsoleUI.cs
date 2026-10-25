using FluentResults;

namespace Alura.Adopet.Console.UI;

public static class ConsoleUI
{
    public static void ExibeResultado(Result result)
    {
        System.Console.ForegroundColor = ConsoleColor.Green;

        try
        {
            if (result.IsFailed)
            {
                ExibeFalha(result);
            }
        }
        finally
        {
            System.Console.ForegroundColor = ConsoleColor.White;
        }
    }

    private static void ExibeFalha(Result result)
    {
        var error = result.Errors.First();

        System.Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine($"Aconteceu uma exceção: {error.Message}");
    }
}