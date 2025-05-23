using Domain.Exceptions;
using Domain.Shared.Cliente;

namespace Domain.ValueObjects.Cliente
{
    public sealed class ClienteInfo
    {

        public EmpresaInfo EmpresaInfo { get; private set; }
        public PessoaFisicaInfo PessoaFisicaInfo { get; private set; }
        public string Endereco { get; private set; }
        public string Bairro { get; private set; }
        public string CEP { get; private set; }
        public string Telefone { get; private set; }


        //public EmpresaInfo EmpresaInfo { get; set; }
        //public PessoaFisicaInfo PessoaFisicaInfo { get; set; }
        //public string Endereco { get; set; }
        //public string Bairro { get; set; }
        //public string CEP { get; set; }
        //public string Telefone { get; set; }

        private ClienteInfo() { }

        public ClienteInfo(EmpresaInfo empresaInfo,
                           PessoaFisicaInfo pessoaFisicaInfo,
                           string endereco,
                           string bairro,
                           string cep,
                           string telefone)
        {
            EmpresaInfo = empresaInfo;
            PessoaFisicaInfo = pessoaFisicaInfo;
            Endereco = endereco;
            Bairro = bairro;
            CEP = cep;
            Telefone = telefone;

            if (Utils.ValidateTelefone(Telefone) == false)
            {
                throw new MissingRequiredInformation("Digite um Telefone válido");
            }

            if (Utils.ValidateCEP(CEP) == false)
            {
                throw new MissingRequiredInformation("Digite um CEP válido");
            }
        }

    }
}
