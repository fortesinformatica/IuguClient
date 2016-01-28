namespace IuguClientAPI.Interfaces
{
    public interface IIuguApiClient : IIuguApiCustomerClient, IIuguApiSubscriptionClient, IIuguApiPlanClient, IIuguApiClientPaymentMethod, IIuguApiClientInvoice
    {
    }
}