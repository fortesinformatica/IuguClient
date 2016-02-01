using System;
using System.Collections.Generic;
using System.Linq;
using static System.Environment;
using static System.String;

namespace IuguClientAPI.Exceptions
{
    public class IuguErrorException : Exception
    {
        public IReadOnlyDictionary<string, string[]> Erros { get; }

        public IuguErrorException(IReadOnlyDictionary<string, string[]> erros)
            : base($"Alguns campos estão incorretos{NewLine}{MontaMensagemDaListaDeErros(erros)}")
        {
            Erros = erros;
        }

        private static string MontaMensagemDaListaDeErros(IReadOnlyDictionary<string, string[]> erros)
            => Join(NewLine, erros.Select(d => $"O campo {d.Key} possui os seguintes erros: {Join(", ", d.Value)}"));
    }
}