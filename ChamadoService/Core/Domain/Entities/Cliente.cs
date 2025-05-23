using Domain.Exceptions;
using Domain.Ports;
using Domain.Shared.Cliente;
using Domain.ValueObjects.Cliente;

namespace Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Contrato { get; set; }
        public ClienteInfo ClienteInfo { get; set; }

        private Cliente() { }

        public Cliente(int id, string contrato, ClienteInfo clienteInfo) 
        {
            Id = id;
            Contrato = contrato;
            ClienteInfo = clienteInfo;
        }

        private void ValidateState()
        {

            if (ClienteInfo.EmpresaInfo is null && ClienteInfo.PessoaFisicaInfo is null)
                throw new MissingRequiredInformation("É preciso informar empresa ou pessoa física");

            if (ClienteInfo.EmpresaInfo is not null && ClienteInfo.PessoaFisicaInfo is not null)
                throw new InvalidClientTypeException("Não pode ser Pessoa Física e Empresa ao mesmo tempo");
        }
        public async Task Save(IClienteRepository clienteRepository)
        {
            this.ValidateState();
            if (this.Id == 0)
            {
                this.Id = await clienteRepository.Criar(this);
            }
            else
            {
                //await clienteRepository.Update(this);
            }
        }
    }
}