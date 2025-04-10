using Domain.DomainEntities;

namespace Application.Clientes.DTO
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Contrato { get; set; }

        public static Cliente MapToEntity(ClienteDTO clienteDTO)
        {
            return new Cliente
            {
                Id = clienteDTO.Id,
                Nome = clienteDTO.Nome,
                Contrato = clienteDTO.Contrato,
            }
        }
    }
}
