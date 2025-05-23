
using Domain.Exceptions;
using Domain.Shared.Cliente;

namespace Domain.ValueObjects.Cliente
{
    public sealed class PessoaFisicaInfo
    {
        public string Nome { get; private set; }
        public string CPF { get; private set; }

        //public string Nome { get; set; }
        //public string CPF { get; set; }

        private PessoaFisicaInfo() { }


        public PessoaFisicaInfo(string nome, string cpf)
        {
            
            Nome = nome;
            CPF = cpf;

            if (Utils.ValidateCPF(CPF) == false)
            {
                throw new MissingRequiredInformation("Digite um CPF válido");
            }
        }
    }
}
