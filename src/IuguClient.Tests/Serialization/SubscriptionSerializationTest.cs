using IuguClientAPI.Models;
using Newtonsoft.Json;
using NUnit.Framework;

namespace IuguClientAPI.Tests.Serialization
{
    [TestFixture]
    public class SubscriptionSerializationTest
    {
        [Test]
        public void DeserializeSubscription()
        {
            var deserializeObject = JsonConvert.DeserializeObject<IuguSubscription>(JSON);
            Assert.IsNotNull(deserializeObject);
        }

        #region json

        private const string JSON = @"{
    ""id"": ""ECF36F9AAF374D76A48646EDE8FE806D"",
    ""suspended"": false,
    ""plan_identifier"": ""id1"",
    ""price_cents"": 200,
    ""currency"": ""BRL"",
    ""features"": {
        ""feat"": {
            ""name"": ""Feature"",
            ""value"": 0
        }
    },
    ""expires_at"": null,
    ""created_at"": ""2013-11-19T11:24:29-02:00"",
    ""updated_at"": ""2013-11-19T11:24:43-02:00"",
    ""customer_name"": ""Nome do Cliente"",
    ""customer_email"": ""email@email.com"",
    ""cycled_at"": null,
    ""credits_min"": 0,
    ""credits_cycle"": null,
    ""customer_id"": ""FF3149CE52CB4A789925F154B489BFDD"",
    ""plan_name"": ""plan1"",
    ""customer_ref"": ""Nome do Cliente"",
    ""plan_ref"": ""plan1"",
    ""active"": true,
    ""in_trial"": null,
    ""credits"": 0,
    ""credits_based"": false,
    ""recent_invoices"": null,
    ""subitems"": [{
        ""id"": ""6D518D88B33F48FEA8964D5573E220D3"",
        ""description"": ""Item um"",
        ""quantity"": 1,
        ""price_cents"": 1000,
        ""price"": ""R$ 10,00"",
        ""total"": ""R$ 10,00""
    }],
    ""logs"": [{
        ""id"": ""477388CC4C024520B552641724A62970"",
        ""description"": ""Fatura criada"",
        ""notes"": ""Fatura criada 1x Ativação de Assinatura: plan1 = R$ 2,00;1x Item um = R$ 10,00;"",
        ""created_at"": ""2013-11-19T11:24:43-02:00""
    }, {
        ""id"": ""706436F169CE465B806163964A25400A"",
        ""description"": ""Assinatura Criada"",
        ""notes"": ""Assinatura Criada"",
        ""created_at"": ""2013-11-19T11:24:29-02:00""
    }],
    ""custom_variables"":[]
}";

        #endregion
    }
}
