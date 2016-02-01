using System;

namespace IuguClientAPI.Exceptions
{
    public class IuguUnauthorizedException : Exception
    {
        public IuguUnauthorizedException() : base("Você não está autenticado ou seu IuguApiToken é invalido") { }
    }
}