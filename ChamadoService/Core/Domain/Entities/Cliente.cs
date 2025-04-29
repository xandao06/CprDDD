using Domain.Exceptions;
using Domain.Ports;
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
                    ClienteTypeId.Telefone.Length <= 10 ||
                    ClienteTypeId.CEP.Length <= 8)
            {
                throw new InvalidClientTypeException();
            }

            if (Contrato == null)
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