using Domain.Exceptions;
using Domain.Shared.Cliente;

namespace Domain.ValueObjects.Cliente
{
    public class ClienteInfo
    {
        public EmpresaInfo EmpresaInfo { get; set; }
        public PessoaFisicaInfo PessoaFisicaInfo { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Telefone { get; set; }

        private ClienteInfo() { }

        public ClienteInfo(EmpresaInfo empresaInfo,
                           PessoaFisicaInfo pessoaFisicaInfo,
                           string endereco,
                           string bairro,
                           string cep,
                           string telefone)
        {
            if (Utils.ValidateTelefone(Telefone) == false)
            {
                throw new MissingRequiredInformation("Digite um Telefone válido");
            }

            if (Utils.ValidateCEP(CEP) == false)
            {
                throw new MissingRequiredInformation("Digite um CEP válido");
            }

            EmpresaInfo = empresaInfo;
            PessoaFisicaInfo = pessoaFisicaInfo;
            Endereco = endereco;
            Bairro = bairro;
            CEP = cep;
            Telefone = telefone;
        }

    }
}
