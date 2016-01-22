using System.Collections.Generic;
using System.Threading.Tasks;
using IuguClientAPI.Models;

namespace IuguClientAPI
{
    public partial class IuguApiClient
    {
        private const string INVOICEURLSUFFIX = "/invoices";
        private const string INVOICEURLSUFFIXWITHID = "/invoices/{id}";

        /// <summary>
        /// Cria uma Fatura para um Cliente
        /// </summary>
        /// <param name="invoiceToCreate">Fatura para ser criada</param>
        /// <returns>Fatura criada</returns>
        public async Task<IuguInvoice> CreateInvoice(IuguInvoice invoiceToCreate) => await Post(invoiceToCreate, INVOICEURLSUFFIX);

        /// <summary>
        /// Cria uma Fatura para um Cliente sincronamente
        /// </summary>
        /// <param name="invoiceToCreate">Fatura para ser criada</param>
        /// <returns>Fatura criada</returns>
        public IuguInvoice CreateInvoiceSync(IuguInvoice invoiceToCreate) => Post(invoiceToCreate, INVOICEURLSUFFIX).Result;

        /// <summary>
        /// Retorna os dados de uma Fatura
        /// </summary>
        /// <param name="invoiceId">Id da Fatura</param>
        /// <returns>Fatura</returns>
        public async Task<IuguInvoice> GetInvoiceById(string invoiceId) => await Get<IuguInvoice>(invoiceId, INVOICEURLSUFFIXWITHID);

        /// <summary>
        /// Retorna os dados de uma Fatura sincronamente
        /// </summary>
        /// <param name="invoiceId">Id da Fatura</param>
        /// <returns>Fatura</returns>
        public IuguInvoice GetInvoiceByIdSync(string invoiceId) => Get<IuguInvoice>(invoiceId, INVOICEURLSUFFIXWITHID).Result;

        /// <summary>
        /// Altera os dados de uma Fatura, quaisquer parâmetros não informados não serão alterados. 
        /// A Fatura pode ser alterada completamente se estiver com status de Rascunho. Caso esteja Pendente, somente logs podem ser alterados. Canceladas e Pagas não podem ser alteradas.
        /// </summary>
        /// <param name="invoiceToUpdate">Fatura para ser atualizada</param>
        /// <returns>Fatura atualizada</returns>
        public async Task<IuguInvoice> UpdateInvoice(IuguInvoice invoiceToUpdate) => await Put(invoiceToUpdate, invoiceToUpdate.Id, INVOICEURLSUFFIXWITHID);

        /// <summary>
        /// Altera os dados sincronamente de uma Fatura, quaisquer parâmetros não informados não serão alterados. 
        /// A Fatura pode ser alterada completamente se estiver com status de Rascunho. Caso esteja Pendente, somente logs podem ser alterados. Canceladas e Pagas não podem ser alteradas.
        /// </summary>
        /// <param name="invoiceToUpdate">Fatura para ser atualizada</param>
        /// <returns>Fatura atualizada</returns>
        public IuguInvoice UpdateInvoiceSync(IuguInvoice invoiceToUpdate) => Put(invoiceToUpdate, invoiceToUpdate.Id, INVOICEURLSUFFIXWITHID).Result;

        /// <summary>
        /// Remove uma Fatura permanentemente.
        /// </summary>
        /// <param name="invoiceId">Id da Fatura</param>
        /// <returns>Fatura removida</returns>
        public async Task<IuguInvoice> DeleteInvoice(string invoiceId) => await Delete<IuguInvoice>(invoiceId, INVOICEURLSUFFIXWITHID);

        /// <summary>
        /// Remove uma Fatura permanentemente sincrono.
        /// </summary>
        /// <param name="invoiceId">Id da Fatura</param>
        /// <returns>Fatura removida</returns>
        public IuguInvoice DeleteInvoiceSync(string invoiceId) => Delete<IuguInvoice>(invoiceId, INVOICEURLSUFFIXWITHID).Result;

        /// <summary>
        /// Gera segunda via de uma Fatura. Somente faturas pendentes podem ter segunda via gerada. A fatura atual é cancelada e uma nova é gerada com status ‘pending’.
        /// </summary>
        /// <param name="invoiceToDuplicate">Fatura para gerar segunda via</param>
        /// <returns>Segunda via da fatura</returns>
        public async Task<IuguInvoice> DuplicateInvoice(IuguInvoice invoiceToDuplicate) => await Post(invoiceToDuplicate, new Dictionary<string, string> { { "id", invoiceToDuplicate.Id } }, $"{INVOICEURLSUFFIXWITHID}/duplicate");

        /// <summary>
        /// Gera segunda via de uma Fatura sincronamente. Somente faturas pendentes podem ter segunda via gerada. A fatura atual é cancelada e uma nova é gerada com status ‘pending’.
        /// </summary>
        /// <param name="invoiceToDuplicate">Fatura para gerar segunda via</param>
        /// <returns>Segunda via da fatura</returns>
        public IuguInvoice DuplicateInvoiceSync(IuguInvoice invoiceToDuplicate) => Post(invoiceToDuplicate, new Dictionary<string, string> { { "id", invoiceToDuplicate.Id } }, $"{INVOICEURLSUFFIXWITHID}/duplicate").Result;

        /// <summary>
        /// Cancela uma Fatura.
        /// </summary>
        /// <param name="invoiceId">Id da Fatura</param>
        /// <returns>Fatura cancelada</returns>
        public async Task<IuguInvoice> CancelInvoice(string invoiceId) => await Put<IuguInvoice>(invoiceId, $"{INVOICEURLSUFFIXWITHID}/cancel");

        /// <summary>
        /// Cancela uma Fatura sincronamente.
        /// </summary>
        /// <param name="invoiceId">Id da Fatura</param>
        /// <returns>Fatura cancelada</returns>
        public IuguInvoice CancelInvoiceSync(string invoiceId) => Put<IuguInvoice>(invoiceId, $"{INVOICEURLSUFFIXWITHID}/cancel").Result;

        /// <summary>
        /// Efetua o reembolso de uma Fatura. Somente alguns meios de pagamento permitem o reembolso, como por exemplo o Cartão de Crédito. Após o reembolso, a Fatura fica com o status de refunded.
        /// </summary>
        /// <param name="invoiceId">Id da fatura</param>
        /// <returns>Fatura reembolsada</returns>
        public async Task<IuguInvoice> RefundInvoice(string invoiceId) => await Post<IuguInvoice>(invoiceId, $"{INVOICEURLSUFFIXWITHID}/refund");

        /// <summary>
        /// Efetua o reembolso de uma Fatura. Somente alguns meios de pagamento permitem o reembolso, como por exemplo o Cartão de Crédito. Após o reembolso, a Fatura fica com o status de refunded.
        /// </summary>
        /// <param name="invoiceId">Id da fatura</param>
        /// <returns>Fatura reembolsada</returns>
        public IuguInvoice RefundInvoiceSync(string invoiceId) => Post<IuguInvoice>(invoiceId, $"{INVOICEURLSUFFIXWITHID}/refund").Result;
    }
}
