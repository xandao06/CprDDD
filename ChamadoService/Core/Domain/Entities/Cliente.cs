using Domain.Exceptions;
using Domain.Ports;
using Domain.Shared.Cliente;
using Domain.ValueObjects.Cliente;

namespace Domain.Entities
{
    public class Cliente
    {
        //public int Id { get; set; }
        //public string Contrato { get; set; }
        //public ClienteInfo ClienteInfo { get; set; }

        public int Id { get; private set; }
        public string Contrato { get; private set; }
        public ClienteInfo ClienteInfo { get; private set; }


        private Cliente() { }

        public Cliente(string contrato, ClienteInfo clienteInfo)
        {
            Contrato = contrato ?? throw new ArgumentNullException(nameof(contrato));
            ClienteInfo = clienteInfo ?? throw new ArgumentNullException(nameof(clienteInfo));
            ValidateState();
        }
        //public Cliente(int id, string contrato, ClienteInfo clienteInfo) 
        //{
        //    Id = id;
        //    Contrato = contrato;
        //    ClienteInfo = clienteInfo;
        //}

        private void ValidateState()
        {

            if (ClienteInfo.EmpresaInfo is null && ClienteInfo.PessoaFisicaInfo is null)
                throw new MissingRequiredInformation("É preciso informar empresa ou pessoa física");

            if (ClienteInfo.EmpresaInfo is not null && ClienteInfo.PessoaFisicaInfo is not null)
                throw new InvalidClientTypeException("Não pode ser Pessoa Física e Empresa ao mesmo tempo");
        }

        public async Task Save(IClienteRepository clienteRepository)
        {
            ValidateState();

            // sempre cria, pois o cadastro vem sem Id
            Id = await clienteRepository.Criar(this);
        }

        //public async Task Save(IClienteRepository clienteRepository)
        //{
        //    this.ValidateState();
        //    if (this.Id == 0)
        //    {
        //        this.Id = await clienteRepository.Criar(this);
        //    }
        //    else
        //    {
        //        //await clienteRepository.Update(this);
        //    }
        //}
    }
}