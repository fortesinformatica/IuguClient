using System;
using NSubstitute;
using RestSharp;

namespace IuguClientAPI.Tests
{
    public abstract class BaseStep<T>
    {
        protected readonly IRestClient _restClient;
        protected readonly IRestResponse<T> _restResponse;

        protected BaseStep()
        {
            _restClient = CrudStepsBase.RestClient = Substitute.For<IRestClient>();
            _restResponse = Substitute.For<IRestResponse<T>>();
        }

        protected T CallMethodAndMockResponse(Func<T> function, T dataToReturn)
        {
            _restResponse.Data.Returns(dataToReturn);
            _restClient.ExecuteTaskAsync<T>(Arg.Any<IRestRequest>()).ReturnsForAnyArgs(_restResponse);
            return function();
        }
    }
}