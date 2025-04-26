using Domain.Enums.Cliente;

namespace Domain.ValueObjetcs.Cliente
{
    public class ClienteInfo
    {
        public EmpresaInfo EmpresaInfo { get; set; }
        public PessoaFisicaInfo PessoaFisicaInfo { get; set;}
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Telefone { get; set; }
    }
}
