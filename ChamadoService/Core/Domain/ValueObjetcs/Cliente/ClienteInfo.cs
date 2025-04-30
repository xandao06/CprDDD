using Domain.Enums.Cliente;

namespace Domain.ValueObjetcs.Cliente
{
    public class ClienteInfo
    {
        public ClienteTypeInfo ClienteTypeInfo { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Telefone { get; set; }
    }
}
