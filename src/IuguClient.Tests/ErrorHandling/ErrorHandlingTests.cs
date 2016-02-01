using System.Collections.Generic;
using System.Net;
using IuguClientAPI.Exceptions;
using IuguClientAPI.Models;
using NSubstitute;
using NUnit.Framework;
using RestSharp;

namespace IuguClientAPI.Tests.ErrorHandling
{
    [TestFixture]
    public class ErrorHandlingTests
    {
        private const string ERROR_JSON = @"{
    ""errors"": {
        ""email"": [
            ""não pode ficar em branco"",
            ""não é válido""
        ]
    }
}";
        private IuguApiClient _sut;

        [Test]
        public void AfterAnyRequestWhenReceived401FromIuguShowThrowIuguUnauthorizedException()
        {
            var restClient = Substitute.For<IRestClient>();
            var response = Substitute.For<IRestResponse>();
            _sut = new IuguApiClient(restClient);

            response.StatusCode.Returns(HttpStatusCode.Unauthorized);
            restClient.Execute(Arg.Any<IRestRequest>()).ReturnsForAnyArgs(response);

            var exception = Assert.Throws<IuguUnauthorizedException>(() => _sut.CreatePlanSync(new IuguPlan("Core", "core_basico", 1, IuguIntervalType.Months, IuguCurrencyType.BRL, 7500)));
            Assert.AreEqual("Você não está autenticado ou seu IuguApiToken é invalido", exception.Message);
        }

        [Test]
        public void AfterAnyRequestWhenReceived422FromIuguShowThrowIuguErrorException()
        {
            var restClient = Substitute.For<IRestClient>();
            var response = Substitute.For<IRestResponse>();
            _sut = new IuguApiClient(restClient);

            response.Content.Returns(ERROR_JSON);
            response.StatusCode.Returns((HttpStatusCode)422);
            restClient.Execute(Arg.Any<IRestRequest>()).ReturnsForAnyArgs(response);

            var expected = new Dictionary<string, string[]>
            {
                ["email"] = new[] { "não pode ficar em branco", "não é válido" }
            };

            var exception = Assert.Throws<IuguErrorException>(() => _sut.CreatePlanSync(new IuguPlan("Core", "core_basico", 1, IuguIntervalType.Months, IuguCurrencyType.BRL, 7500)));
            CollectionAssert.AreEquivalent(expected, exception.Erros);
            Assert.AreEqual("Alguns campos estão incorretos, olhe a propriedade Erros para mais detalhes.", exception.Message);
        }
    }
}
