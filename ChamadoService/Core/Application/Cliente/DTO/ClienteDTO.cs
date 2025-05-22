namespace Application.Cliente.DTO
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string Contrato { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Telefone { get; set; }
        public EmpresaInfoDTO EmpresaInfo { get; set; }
        public PessoaFisicaInfoDTO PessoaFisicaInfo { get; set; }

        }
    }

