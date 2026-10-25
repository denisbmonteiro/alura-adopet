using System.Reflection;
using Alura.Adopet.Console.Util;
using FluentResults;

namespace Alura.Adopet.Console.Comandos;

[DocComando(instrucao: "help", documentacao: "adopet help comando que exibe informações da ajuda. \nadopet help <NOME_COMANDO> para acessar a ajuda de um comando específico.")]
internal class Help : IComando
{
    private Dictionary<string, DocComando> docs;

    public Help()
    {
        docs = DocumentacaoDoSistema.ToDictionary(Assembly.GetExecutingAssembly());
    }

    public Task<Result> ExecutarAsync(string[] args)
    {
        try
        {
            return Task.FromResult(Result.Ok().WithSuccess(new SuccessWithDocs(GerarDocumentacao(args))));
        }
        catch (Exception ex)
        {
            return Task.FromResult(Result.Fail(new Error("Exibição da documentação falhou!").CausedBy(ex)));
        }
    }

    private IEnumerable<string> GerarDocumentacao(string[] parametros)
    {
        var resultado = new List<string>();

        if (parametros.Length == 1)
        {
            foreach (var doc in docs.Values)
            {
                resultado.Add(doc.Documentacao);
            }
        }
        else if (parametros.Length == 2)
        {
            string comandoASerExibido = parametros[1];
            if (docs.ContainsKey(comandoASerExibido))
            {
                var comando = docs[comandoASerExibido];
                resultado.Add(comando.Documentacao);
            }
            else
            {
                resultado.Add("Comando não encontrado!");
            }
        }

        return resultado;
    }
}