using System;
using System.Collections.Generic;

namespace IuguClientAPI.Exceptions
{
    public class IuguErrorException : Exception
    {
        public IReadOnlyDictionary<string, string[]> Erros { get; }

        public IuguErrorException(IReadOnlyDictionary<string, string[]> erros)
            : base($"Alguns campos estão incorretos, olhe a propriedade {nameof(Erros)} para mais detalhes.")
        {
            Erros = erros;
        }
    }
}