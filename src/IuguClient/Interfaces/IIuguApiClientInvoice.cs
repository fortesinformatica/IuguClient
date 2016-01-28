using System.Threading.Tasks;
using IuguClientAPI.Models;

namespace IuguClientAPI.Interfaces
{
    public interface IIuguApiClientInvoice
    {
        Task<IuguInvoice> CreateInvoice(IuguInvoice invoiceToCreate);
        IuguInvoice CreateInvoiceSync(IuguInvoice invoiceToCreate);
        Task<IuguInvoice> GetInvoiceById(string invoiceId);
        IuguInvoice GetInvoiceByIdSync(string invoiceId);
        Task<IuguInvoice> UpdateInvoice(IuguInvoice invoiceToUpdate);
        IuguInvoice UpdateInvoiceSync(IuguInvoice invoiceToUpdate);
        Task<IuguInvoice> DeleteInvoice(string invoiceId);
        IuguInvoice DeleteInvoiceSync(string invoiceId);
        Task<IuguInvoice> DuplicateInvoice(IuguInvoice invoiceToDuplicate);
        IuguInvoice DuplicateInvoiceSync(IuguInvoice invoiceToDuplicate);
        Task<IuguInvoice> CancelInvoice(string invoiceId);
        IuguInvoice CancelInvoiceSync(string invoiceId);
        Task<IuguInvoice> RefundInvoice(string invoiceId);
        IuguInvoice RefundInvoiceSync(string invoiceId);
    }
}
