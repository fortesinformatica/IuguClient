using System.Threading.Tasks;
using IuguClientAPI.Models;

namespace IuguClientAPI.Interfaces
{
    public interface IIuguApiClientPaymentMethod
    {
        Task<IuguPaymentMethod> CreatePaymentMethod(IuguPaymentMethod paymentMethod);
        IuguPaymentMethod CreatePaymentMethodSync(IuguPaymentMethod paymentMethod);
        Task<IuguPaymentMethod> UpdatePaymentMethod(IuguPaymentMethod paymentMethod, string clientId);
        IuguPaymentMethod UpdatePaymentMethodSync(IuguPaymentMethod paymentMethod, string clientId);
        Task<IuguPaymentMethod> DeletePaymentMethod(string paymentMethodId);
        IuguPaymentMethod DeletePaymentMethodSync(string paymentMethodId);
    }
}
