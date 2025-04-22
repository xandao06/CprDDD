
using Domain.ValueObjetcs.Cliente;

namespace Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Contrato { get; set; }
        public ClienteInfo ClienteTypeId { get; set; }
    }
}
