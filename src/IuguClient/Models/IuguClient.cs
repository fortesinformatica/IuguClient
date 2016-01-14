using Newtonsoft.Json;

namespace IuguClientAPI.Models
{
    public class IuguClient
    {
        public string Id { get; }
        public string Email { get; }
        public string Name { get; }
        public string CpfCnpj { get; }
        public string Notes { get; }

        public IuguClient(string email, string name = null, string cpf_cnpj = null, string notes = null)
        {
            Email = email;
            Name = name;
            CpfCnpj = cpf_cnpj;
            Notes = notes;
        }

        [JsonConstructor]
        public IuguClient(string id, string email, string name = null, string cpf_cnpj = null, string notes = null)
        {
            Id = id;
            Email = email;
            Name = name;
            CpfCnpj = cpf_cnpj;
            Notes = notes;
        }
    }
}