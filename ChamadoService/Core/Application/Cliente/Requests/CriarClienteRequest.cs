using Application.Cliente.DTO;

namespace Application.Cliente.Requests
{
    public class CriarClienteRequest
    {
        public ClienteDTO ClienteData { get; set; }
        public PessoaFisicaInfoDTO PessoaFisicaData { get; set; }
        public EmpresaInfoDTO EmpresaInfoData { get; set; }
    }
}
