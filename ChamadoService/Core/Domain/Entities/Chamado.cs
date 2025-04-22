using Domain.Enums.Chamado;
using Action = Domain.Enums.Action;

namespace Domain.Entities
{
    public class Chamado
    {
        public Chamado() 
        {
            this.Status = Status.Criado;
        }

        public int Id { get; set; }
        public DateTime AbertoData { get; set; } = DateTime.Now;
        public DateTime ConcluidoData { get; set; }
        public DateTime AbertoHora { get; set; } = DateTime.Now;
        public DateTime ConcluidoHora { get; set; }
        public string Descricao { get; set; }
        public string Urgencia { get; set; }
        public string Tecnico { get; set; }
        private Status Status { get; set; }
        public Status CurrentStatus { get { return this.Status; } }

        public void ChangeState(Action action)
        {
            this.Status = (this.Status, action) switch
            {
                (Status.Criado, Action.Criar) => Status.Pendente,
                (Status.Criado, Action.Encerrar) => Status.Encerrado,
                _ => this.Status
            };
        }
    }
}
