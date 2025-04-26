using Application.Cliente.DTO;
using Application.Cliente.Ports;
using Application.Cliente.Requests;
using Application.Cliente.Responses;
using Domain.Ports;

namespace Application
{
    public class ClienteManager : IClienteManager
    {

        private IClienteRepository _clienteRepository;
        public ClienteManager(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public async Task<ClienteResponse> CriarCliente(CriarClienteRequest request)
        {
            try
            {
                var cliente = ClienteDTO.MapToEntity(request.Data);

                request.Data.Id = await _clienteRepository.Criar(cliente);

                return new ClienteResponse
                {
                    Data = request.Data,
                    Success = true,
                };
            }
            catch (Exception)
            {
                return new ClienteResponse
                {
                    Success = false,
                    ErrorCode = ErrorCodes.COULD_NOT_STORE_DATA,
                    Message = "Ocorreu um erro ao salvar no banco"
                };
            }
            
        }
    }
}
