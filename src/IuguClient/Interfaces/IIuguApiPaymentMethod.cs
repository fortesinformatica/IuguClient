using System.Threading.Tasks;
using IuguClientAPI.Models;

namespace IuguClientAPI.Interfaces
{
    public interface IIuguApiPaymentMethod
    {
        Task<IuguPaymentMethod> CreatePaymentMethod(IuguPaymentMethod paymentMethod);
    }
}