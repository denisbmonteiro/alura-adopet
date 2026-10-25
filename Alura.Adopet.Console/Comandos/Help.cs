using System.Reflection;
using Alura.Adopet.Console.Util;
using FluentResults;

namespace Alura.Adopet.Console.Comandos;

[DocComando(instrucao: "help", documentacao: "adopet help comando que exibe informações da ajuda. \nadopet help <NOME_COMANDO> para acessar a ajuda de um comando específico.")]
internal class Help : IComando
{
    private readonly Dictionary<string, DocComando> _docs;
    private readonly string? _comando;

    public Help(string? comando)
    {
        _docs = DocumentacaoDoSistema.ToDictionary(Assembly.GetExecutingAssembly());
        _comando = comando;
    }

    public Task<Result> ExecutarAsync()
    {
        try
        {
            return Task.FromResult(Result.Ok().WithSuccess(new SuccessWithDocs(GerarDocumentacao())));
        }
        catch (Exception ex)
        {
            return Task.FromResult(Result.Fail(new Error("Exibição da documentação falhou!").CausedBy(ex)));
        }
    }

    private IEnumerable<string> GerarDocumentacao()
    {
        var resultado = new List<string>();

        if (_comando is null)
        {
            foreach (var doc in _docs.Values)
            {
                resultado.Add(doc.Documentacao);
            }
        }
        else
        {
            if (_docs.ContainsKey(_comando))
            {
                var comando = _docs[_comando];
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