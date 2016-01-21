using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
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
            CrudStepsBase.Asserter = MatchRequest;
        }

        protected T CallMethodAndMockResponse(Func<T> function, T dataToReturn)
        {
            _restResponse.Data.Returns(dataToReturn);
            _restClient.ExecuteTaskAsync<T>(Arg.Any<IRestRequest>()).ReturnsForAnyArgs(_restResponse);
            return function();
        }

        private Task<IRestResponse<T>> MatchRequest(Expression<Predicate<IRestRequest>> exp)
            => _restClient.Received().ExecuteTaskAsync<T>(Arg.Is(exp));

    }
}