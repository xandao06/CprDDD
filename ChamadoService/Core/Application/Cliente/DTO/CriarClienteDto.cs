namespace Application.Cliente.Dto
{
    public class CriarClienteDto
    {
        public string Contrato { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Telefone { get; set; }
        public EmpresaInfoDto EmpresaInfo { get; set; }
        public PessoaFisicaInfoDto PessoaFisicaInfo { get; set; }

        }
    }

