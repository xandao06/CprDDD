//using Application.Clientes.DTO;
//using Application.Clientes.Ports;
//using Application.Clientes.Requests;
//using Application.Clientes.Responses;
//using Domain.Ports;

//namespace Application
//{
//    public class ClienteManager : IClienteManager
//    {

//        private IClienteRepository _clienteRepository;
//        public ClienteManager(IClienteRepository clienteRepository) 
//        {
//            _clienteRepository = clienteRepository;
//        }
//        public Task<ClienteResponse> CriarCliente(CriarClienteRequest request)
//        {
//            var cliente = ClienteDTO;

//            _clienteRepository.Criar();
//        }
//    }
//}
