using System;
using Newtonsoft.Json;

namespace IuguClientAPI.Models
{
    public class IuguCustomer
    {
        public IuguCustomer(string email, string name = null, string cpfCnpj = null, string notes = null, object[] customVariables = null)
        {
            Email = email;
            Name = name;
            CpfCnpj = cpfCnpj;
            Notes = notes;
            CustomVariables = customVariables;
        }

        [JsonConstructor]
        public IuguCustomer(string id, string email, string name, string notes, DateTime? createdAt, DateTime? updatedAt, object[] customVariables, string cpfCnpj)
        {
            Id = id;
            Email = email;
            Name = name;
            Notes = notes;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            CustomVariables = customVariables;
            CpfCnpj = cpfCnpj;
        }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("custom_variables")]
        public object[] CustomVariables { get; set; }

        [JsonProperty("cpf_cnpj")]
        public string CpfCnpj { get; set; }
    }
}