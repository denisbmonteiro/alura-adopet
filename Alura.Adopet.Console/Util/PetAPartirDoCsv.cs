using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Util;

public static class PetAPartirDoCsv
{
    public static Pet ConverteDoTexto(this string? linha)
    {
        ArgumentNullException.ThrowIfNull(linha);
        ArgumentException.ThrowIfNullOrEmpty(linha);

        string[]? propriedades = linha.Split(';');

        if (propriedades.Length != 3)
            throw new ArgumentException("Texto inválido.");

        bool sucesso = Guid.TryParse(propriedades[0], out Guid petId);

        if (!sucesso)
            throw new ArgumentException("Guid inválido.");

        sucesso = int.TryParse(propriedades[2], out int tipoPet);

        if (!sucesso || (tipoPet != 0 && tipoPet != 1))
            throw new ArgumentException("Tipo de Pet inválido.");

        var pet = new Pet(
            petId,
            propriedades[1],
            tipoPet == 0 ? TipoPet.Gato : TipoPet.Cachorro
        );

        return pet;
    }
}