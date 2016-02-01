using System;

namespace IuguClientAPI.Exceptions
{
    public class IuguUnauthorizedException : Exception
    {
        public IuguUnauthorizedException() : base("Voc� n�o est� autenticado ou seu IuguApiToken � invalido") { }
    }
}