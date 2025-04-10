
namespace Domain.DomainEntities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Contrato { get; set; }
        public PersonId DocumentId { get; set; }
    }
}
