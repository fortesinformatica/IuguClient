using System;
using System.Collections.Generic;
using IuguClientAPI.Models;
using Newtonsoft.Json;
using NUnit.Framework;

namespace IuguClientAPI.Tests.Serialization
{
    [TestFixture]
    public class InvoiceSerialization : BaseTestSetup
    {
        public static IuguInvoice IuguInvoice => JsonConvert.DeserializeObject<IuguInvoice>(JSON);

        [Test]
        public void SerializeInvoice()
        {
            var iuguInvoice = new IuguInvoice("0958D2AAD34049AB889583E26DFA0BF1", "teste@teste.com", DateTime.Now, new List<IuguInvoiceItem>(), "http://app.coremanagerdev.com.br/#/expirado",
                "http://app.coremanagerdev.com.br/#/webhook/fatura", null, null, null, null, null, "A118D2AAD34049AB889583E26DFA2FR6", null, "111ASDF222DFSFS656598DFDFS54", PaymentOptions.CreditCard,
                null, null, null);
            var json = JsonConvert.SerializeObject(iuguInvoice);
            Assert.IsNotEmpty(json);
        }

        [Test]
        public void DeserializeInvoice()
        {
            var deserializeObject = IuguInvoice;
            Assert.IsNotNull(deserializeObject);
        }

        const string JSON = @"
                    {
                        ""id"": ""0958D2AAD34049AB889583E26DFA0BF1"",
                        ""due_date"": ""2013-11-30"",
                        ""currency"": ""BRL"",
                        ""discount_cents"": null,
                        ""email"": ""teste@teste.com"",
                        ""items_total_cents"": 1000,
                        ""notification_url"": null,
                        ""return_url"": null,
                        ""status"": ""pending"",
                        ""tax_cents"": null,
                        ""updated_at"": ""2014-06-17T09:58:05-03:00"",
                        ""total_cents"": 1000,
                        ""paid_at"": null,
                        ""secure_id"": ""0958d2aa-d340-49ab-8895-83e26dfa0bf1-2f4c"",
                        ""secure_url"": ""http://iugu.com/invoices/0958d2aa-d340-49ab-8895-83e26dfa0bf1-2f4c"",
                        ""customer_id"": null,
                        ""user_id"": null,
                        ""total"": ""R$ 10,00"",
                        ""taxes_paid"": ""R$ 0,00"",
                        ""interest"": null,
                        ""discount"": null,
                        ""created_at"": ""17/06, 09:58 h"",
                        ""refundable"": null,
                        ""installments"": null,
                        ""bank_slip"": {
                            ""digitable_line"": ""00000000000000000000000000000000000000000000000"",
                            ""barcode_data"": ""00000000000000000000000000000000000000000000"",
                            ""barcode"": ""http://iugu.com/invoices/barcode/0958d2aa-d340-49ab-8895-83e26dfa0bf1-2f4c""
                        },
                        ""items"": [{
                            ""id"": ""11DA8B1662EC4C30BC4C78AEDC619145"",
                            ""description"": ""Item Um"",
                            ""price_cents"": 1000,
                            ""quantity"": 1,
                            ""created_at"": ""2014-06-17T09:58:05-03:00"",
                            ""updated_at"": ""2014-06-17T09:58:05-03:00"",
                            ""price"": ""R$ 10,00""
                        }],
                        ""variables"": [{
                            ""id"": ""A897DD8BB6B54AE18CA4C48684E72FB9"",
                            ""variable"": ""payment_data.transaction_number"",
                            ""value"": ""1111""
                        }],
                        ""custom_variables"": {},
                        ""logs"": []
                    }";
    }
}
