using System;
using System.Threading.Tasks;
using IuguClientAPI.Models;

namespace IuguClientAPI
{
    public interface IIuguApiClient : IDisposable
    {
        Task<IuguClient> CreateClient(IuguClient client);
        IuguClient CreateClientSync(IuguClient client);
    }
}