using System;
using System.Configuration;
using RestSharp;

namespace IuguClientAPI
{
    public abstract class IuguApi
    {
        protected const string IUGUAPITOKEN = "IuguApiToken";
        protected readonly IRestClient _httpClient;
        protected string _apiToken;

        protected IuguApi(IRestClient httpClient = default(RestClient), string baseUrl = "https://api.iugu.com/v1")
        {
            _apiToken = ConfigurationManager.AppSettings.Get(IUGUAPITOKEN);
            if (string.IsNullOrWhiteSpace(_apiToken))
                throw new ConfigurationErrorsException("IuguApiToken não está configurado no App.config ou Web.config");

            _httpClient = httpClient ?? new RestClient(new Uri(baseUrl));
        }
    }
}
