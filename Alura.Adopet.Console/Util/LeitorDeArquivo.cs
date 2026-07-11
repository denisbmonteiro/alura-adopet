using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Util;

public class LeitorDeArquivo
{
    public List<Pet> RealizaLeitura(string caminhoDoArquivoASerLido)
    {
        var listaDePet = new List<Pet>();

        using (var sr = new StreamReader(caminhoDoArquivoASerLido))
        {
            System.Console.WriteLine("----- Dados a serem importados -----");

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