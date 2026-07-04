using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Util;

internal class LeitorDeArquivo
{
    public List<Pet> RealizaLeitura(string caminhoDoArquivoASerLido)
    {
        var listaDePet = new List<Pet>();

        using (var sr = new StreamReader(caminhoDoArquivoASerLido))
        {
            System.Console.WriteLine("----- Dados a serem importados -----");

            while (!sr.EndOfStream)
            {
                string[]? propriedades = sr.ReadLine()?.Split(';');

                var pet = new Pet(
                    Guid.Parse(propriedades[0]),
                    propriedades[1],
                    int.Parse(propriedades[2]) == 1 ? TipoPet.Gato : TipoPet.Cachorro
                );

                listaDePet.Add(pet);
            }
        }

        return listaDePet;
    }
}