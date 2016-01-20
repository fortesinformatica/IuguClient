using IuguClientAPI.Models;
using Newtonsoft.Json;
using NUnit.Framework;

namespace IuguClientAPI.Tests.Serealization
{
    [TestFixture]
    public class PlanSerializationTest
    {
        public static IuguPlan IuguPlan => JsonConvert.DeserializeObject<IuguPlan>(JSON);

        [Test]
        public void SerializePlan()
        {
            var iuguPlan = new IuguPlan("Core", "core_basico", 1, IuguIntervalType.Months, IuguCurrencyType.BRL, 7500);
            var serializeObject = JsonConvert.SerializeObject(iuguPlan);
            Assert.IsNotEmpty(serializeObject);
        }

        [Test]
        public void DeserializePlan()
        {
            var deserializeObject = IuguPlan;
            Assert.IsNotNull(deserializeObject);
        }

        #region json

        private const string JSON = @"{
    ""id"": ""1"",
    ""name"": ""Plano Básico"",
    ""identifier"": ""basic_plan"",
    ""interval"": 1,
    ""interval_type"": ""months"",
    ""created_at"": ""2014-04-23T17:14:15-03:00"",
    ""updated_at"": ""2014-04-23T17:14:15-03:00"",
    ""prices"": [{
        ""created_at"": ""2014-04-23T17:14:15-03:00"",
        ""currency"": ""BRL"",
        ""id"": ""F465EE77AC424DA2B075133C96FF10CA"",
        ""plan_id"": ""593C92165AF44493B65DE17A216C76D6"",
        ""updated_at"": ""2014-04-23T17:14:15-03:00"",
        ""value_cents"": 1000
    }],
    ""features"": [{
        ""created_at"": ""2014-04-23T17:14:15-03:00"",
        ""id"": ""6101C66D06564E3DB834BCE235A587A6"",
        ""identifier"": ""users"",
        ""important"": null,
        ""name"": ""Número de Usuários"",
        ""plan_id"": ""593C92165AF44493B65DE17A216C76D6"",
        ""position"": 1,
        ""updated_at"": ""2014-04-23T17:14:15-03:00"",
        ""value"": 10
    }]
}";

        #endregion
    }
}