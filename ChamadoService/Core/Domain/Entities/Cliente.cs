using Domain.Exceptions;
using Domain.Ports;
using Domain.Shared;
using Domain.Shared.Cliente;
using Domain.ValueObjetcs.Cliente;

namespace Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Contrato { get; set; }
        public ClienteInfo ClienteTypeId { get; set; }

        private void ValidateState()
        {
            if (ClienteTypeId == null ||
                ClienteTypeId.ClienteTypeInfo == 0 ||
                Contrato == null)
            {
                throw new InvalidClientTypeException();
            }

            if (Utils.ValidateTelefone(this.ClienteTypeId.Telefone) == false)
            {
                throw new MissingRequiredInformation();
            }

            if (Utils.ValidateCNPJ(this.ClienteTypeId.ClienteTypeInfo. == false)
            {
                throw new MissingRequiredInformation();
            }

            if (Utils.ValidateTelefone(this.ClienteTypeId.Telefone) == false)
            {
                throw new MissingRequiredInformation();
            }

            if (Utils.ValidateTelefone(this.ClienteTypeId.Telefone) == false)
            {
                throw new MissingRequiredInformation();
            }

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