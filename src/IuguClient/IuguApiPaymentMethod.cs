using System.Threading.Tasks;
using IuguClientAPI.Interfaces;
using IuguClientAPI.Models;
using RestSharp;

namespace IuguClientAPI
{
    public class IuguApiPaymentMethod : IuguApi, IIuguApiPaymentMethod
    {
        public IuguApiPaymentMethod(IRestClient httpClient = default(RestClient), string baseUrl = "https://api.iugu.com/v1")
            : base(httpClient, baseUrl)
        { }

        public async Task<IuguPaymentMethod> CreatePaymentMethod(IuguPaymentMethod paymentMethod)
        {
            var restRequest = new RestRequest("/", Method.POST).AddJsonBody(paymentMethod);
            var executeTaskAsync = await _httpClient.ExecuteTaskAsync<IuguPaymentMethod>(restRequest);

            return executeTaskAsync.Data;
        }
    }
}
