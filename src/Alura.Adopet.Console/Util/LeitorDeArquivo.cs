using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Util;

public class LeitorDeArquivo
{
    private readonly string _caminhoArquivo;

    public LeitorDeArquivo(string caminhoArquivo)
    {
        _caminhoArquivo = caminhoArquivo;
    }

    public virtual List<Pet>? RealizaLeitura()
    {
        if (string.IsNullOrEmpty(_caminhoArquivo))
            return null;

        var listaDePet = new List<Pet>();

        using (var sr = new StreamReader(_caminhoArquivo))
        {
            while (!sr.EndOfStream)
            {
                var linha = sr.ReadLine();

                if (string.IsNullOrWhiteSpace(linha))
                    continue;

                var pet = linha.ConverteDoTexto();

                listaDePet.Add(pet);
            }
        }

        return listaDePet;
    }
}