using System;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
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
            CrudStepsBase.AsserterSync = MatchSyncRequest;
        }

        protected T CallMethodAndMockResponse(Func<T> function, T dataToReturn)
        {
            CrudStepsBase.SyncRequest = false;
            _restResponse.Data.Returns(dataToReturn);
            _restClient.ExecuteTaskAsync<T>(Arg.Any<IRestRequest>()).ReturnsForAnyArgs(_restResponse);
            return function();
        }

        protected T CallMethodSyncAndMockResponse(Func<T> function, T dataToReturn)
        {
            CrudStepsBase.SyncRequest = true;
            _restResponse.Content.Returns(JsonConvert.SerializeObject(dataToReturn));
            _restResponse.StatusCode.Returns(HttpStatusCode.OK);
            _restClient.Execute(Arg.Any<IRestRequest>()).ReturnsForAnyArgs(_restResponse);
            return function();
        }

        private Task<IRestResponse<T>> MatchRequest(Expression<Predicate<IRestRequest>> exp)
            => _restClient.Received().ExecuteTaskAsync<T>(Arg.Is(exp));

        private IRestResponse MatchSyncRequest(Expression<Predicate<IRestRequest>> exp)
            => _restClient.Received().Execute(Arg.Is(exp));
    }
}