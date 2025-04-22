using Domain.Enums.Cliente;

namespace Domain.ValueObjetcs.Cliente
{
    public class ClienteInfo
    {
        public EmpresaInfo EmpresaInfo { get; set; }
        public PessoaFisicaInfo PessoaFisicaInfo { get; set;}
        public GenericoInfo GenericoInfo { get; set; }
    }
}
