using System.Collections.Generic;
using System.Threading.Tasks;
using IuguClientAPI.Models;

namespace IuguClientAPI
{
    public partial class IuguApiClient
    {
        private const string URLSUFFIX = "customers/{clientId}/payment_methods";
        private const string URLSUFFIXWITHCLIENTID = "customers/{clientId}/payment_methods/{id}";

        public async Task<IuguPaymentMethod> CreatePaymentMethod(IuguPaymentMethod paymentMethod)
            => await Post(paymentMethod, new Dictionary<string, string> { { "clientId", paymentMethod.CustomerId } }, URLSUFFIX);

        public IuguPaymentMethod CreatePaymentMethodSync(IuguPaymentMethod paymentMethod)
            => Post(paymentMethod, new Dictionary<string, string> { {"clientId", paymentMethod.CustomerId} }, URLSUFFIX).Result;

        public async Task<IuguPaymentMethod> UpdatePaymentMethod(IuguPaymentMethod paymentMethod, string clientId)
            => await Put(paymentMethod, new Dictionary<string, string> { { "id", paymentMethod.Id }, { "clienteId", clientId } }, URLSUFFIXWITHCLIENTID);

        public IuguPaymentMethod UpdatePaymentMethodSync(IuguPaymentMethod paymentMethod, string clientId)
            => Put(paymentMethod, new Dictionary<string, string> { { "id", paymentMethod.Id }, { "clienteId", clientId } }, URLSUFFIXWITHCLIENTID).Result;

        public async Task<IuguPaymentMethod> DeletePaymentMethod(string paymentMethodId)
            => await Delete<IuguPaymentMethod>(paymentMethodId, URLSUFFIXWITHCLIENTID);

        public IuguPaymentMethod DeletePaymentMethodSync(string paymentMethodId)
            => Delete<IuguPaymentMethod>(paymentMethodId, URLSUFFIXWITHCLIENTID).Result;
    }
}
