using System.Collections.Generic;
using System.Threading.Tasks;
using IuguClientAPI.Models;

namespace IuguClientAPI
{
    public partial class IuguApiClient
    {
        private const string PAYMENTMETHODURLSUFFIX = "customers/{clientId}/payment_methods";
        private const string PAYMENTMETHODURLSUFFIXWITHCLIENTID = "customers/{clientId}/payment_methods/{id}";

        public async Task<IuguPaymentMethod> CreatePaymentMethod(IuguPaymentMethod paymentMethod)
            => await Post(paymentMethod, new Dictionary<string, string> { { "clientId", paymentMethod.CustomerId } }, PAYMENTMETHODURLSUFFIX);

        public IuguPaymentMethod CreatePaymentMethodSync(IuguPaymentMethod paymentMethod)
            => PostSync(paymentMethod, new Dictionary<string, string> { { "clientId", paymentMethod.CustomerId } }, PAYMENTMETHODURLSUFFIX);

        public async Task<IuguPaymentMethod> UpdatePaymentMethod(IuguPaymentMethod paymentMethod, string clientId)
            => await Put(paymentMethod, new Dictionary<string, string> { { "id", paymentMethod.Id }, { "clienteId", clientId } }, PAYMENTMETHODURLSUFFIXWITHCLIENTID);

        public IuguPaymentMethod UpdatePaymentMethodSync(IuguPaymentMethod paymentMethod, string clientId)
            => PutSync(paymentMethod, new Dictionary<string, string> { { "id", paymentMethod.Id }, { "clienteId", clientId } }, PAYMENTMETHODURLSUFFIXWITHCLIENTID);

        public async Task<IuguPaymentMethod> DeletePaymentMethod(string paymentMethodId)
            => await Delete<IuguPaymentMethod>(paymentMethodId, PAYMENTMETHODURLSUFFIXWITHCLIENTID);

        public IuguPaymentMethod DeletePaymentMethodSync(string paymentMethodId)
            => DeleteSync<IuguPaymentMethod>(paymentMethodId, PAYMENTMETHODURLSUFFIXWITHCLIENTID);
    }
}
